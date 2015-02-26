//  
// Author:
//       Marek Habersack <grendel@twistedcode.net>
// 
// Copyright (c) 2011 Novell, Inc (http://novell.com/)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Util;

namespace Microsoft.Web.Infrastructure.DynamicValidationHelper
{
	sealed class LazyWebROCollection : WebROCollection
	{
		WebROCollection wrapped;
		RequestValidationSource validationSource;
		
		public LazyWebROCollection (RequestValidationSource validationSource, WebROCollection wrapped)
		{
			if (wrapped == null)
				throw new ArgumentNullException ("wrapped");
			
			this.validationSource = validationSource;
			this.wrapped = wrapped;
		}
		
		public new string this [int index] {
			get { return Get (index); }
		}

		public new string this [string name] {
			get { return Get (name); }
			set{ Set (name,value); }
		}
		
		public override string[] AllKeys {
			get { return wrapped.AllKeys; }
		}

		public override int Count {
			get { return wrapped.Count; }
		}
		
		public override NameObjectCollectionBase.KeysCollection Keys {
			get { return wrapped.Keys; }
		}

		public new void Add (NameValueCollection c)
		{
			wrapped.Add (c);
		}
			
		public override void Add (string name, string val)
		{
			wrapped.Add (name, val);
		}
		
		public override void Clear ()
		{
			wrapped.Clear ();
		}

		public override string Get (string name)
		{
			return Validate (name, wrapped.Get (name));
		}

		public override string Get (int index)
		{
			return Validate (wrapped.GetKey (index), wrapped.Get (index));
		}

		public override void GetObjectData (SerializationInfo info, StreamingContext context)
		{
			wrapped.GetObjectData (info, context);
		}
		
		public override IEnumerator GetEnumerator ()
		{
			return wrapped.GetEnumerator ();
		}

		public override string GetKey (int index)
		{
			return wrapped.GetKey (index);
		}

		public override string[] GetValues (int index)
		{
			return wrapped.GetValues (index);
		}

		public override string[] GetValues (string name)
		{
			return wrapped.GetValues (name);
		}

		public override void OnDeserialization (object sender)
		{
			wrapped.OnDeserialization (sender);
		}
		
		public override void Set (string name, string value)
		{
			wrapped.Set (name, value);
		}
		
		string Validate (string key, string value)
		{
			if (String.IsNullOrEmpty (value))
				return value;

			ValidateString (key, value, validationSource);
			return value;
		}

		void ValidateString (string key, string value, RequestValidationSource source)
		{
			if (String.IsNullOrEmpty (value))
				return;
#pragma warning disable 219
			int ignore;
#pragma warning restore 219
			if (IsInvalidString (value, out ignore))
				ThrowValidationException (source.ToString (), key, value);
		}
		bool IsInvalidString (string val)
		{
#pragma warning disable 219
			int validationFailureIndex;
#pragma warning restore 219
			return IsInvalidString (val, out validationFailureIndex);
		}

		bool IsInvalidString (string val, out int validationFailureIndex)
		{
			validationFailureIndex = 0;

			int len = val.Length;
			if (len < 2)
				return false;

			char current = val [0];
			for (int idx = 1; idx < len; idx++) {
				char next = val [idx];
				// See http://secunia.com/advisories/14325
				if (current == '<' || current == '\xff1c') {
					if (next == '!' || next < ' '
					    || (next >= 'a' && next <= 'z')
					    || (next >= 'A' && next <= 'Z')) {
						validationFailureIndex = idx - 1;
						return true;
					}
				} else if (current == '&' && next == '#') {
					validationFailureIndex = idx - 1;
					return true;
				}

				current = next;
			}

			return false;
		}

		void ThrowValidationException (string name, string key, string value)
		{
			string v = "\"" + value + "\"";
			if (v.Length > 20)
				v = v.Substring (0, 16) + "...\"";
		
			string msg = String.Format ("A potentially dangerous Request.{0} value was " +
						    "detected from the client ({1}={2}).", name, key, v);
		
			throw new HttpRequestValidationException (msg);
		}
	}
}
