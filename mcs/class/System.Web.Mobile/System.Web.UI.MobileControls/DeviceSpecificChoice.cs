/**
 * Project   : Mono
 * Namespace : System.Web.UI.MobileControls
 * Class     : DeviceSpecificChoice
 * Author    : Gaurav Vaish
 *
 * Copyright : 2003 with Gaurav Vaish, and with
 *             Ximian Inc
 */

using System.ComponentModel;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.Web.UI;
using System.Web.Mobile;

namespace System.Web.UI.MobileControls
{
	public class DeviceSpecificChoice : IParserAccessor,
	                                    IAttributeAccessor
	{
		private string argument;
		private IDictionary contents;
		private string filter;
		private DeviceSpecific owner;
		private IDictionary templates;
		private string xmlns;

		private static IComparer caseInsensitiveComparer
		                      = new CaseInsensitiveComparer();

		public DeviceSpecificChoice()
		{
		}

		string IAttributeAccessor.GetAttribute(string key)
		{
			object val = Contents[key];
			if(val != null && val is string)
				return (string)val;
			//FIXME
			throw new ArgumentException("DeviceSpecificChoice" +
			                            "_PropetyNotAnAttribute");
		}

		void IAttributeAccessor.SetAttribute(string key, string value)
		{
			Contents[key] = value;
		}

		void IParserAccessor.AddParsedSubObject(object obj)
		{
			if(obj is DeviceSpecificChoiceTemplateContainer)
			{
				DeviceSpecificChoiceTemplateContainer ctr =
				    (DeviceSpecificChoiceTemplateContainer)obj;
				Templates[ctr.Name] = ctr.Template;
			}
		}

		public string Argument
		{
			get
			{
				return this.argument;
			}
			set
			{
				this.argument = value;
			}
		}

		public IDictionary Contents
		{
			get
			{
				if(this.contents == null)
				{
					this.contents = new ListDictionary(caseInsensitiveComparer);
				}
				return this.contents;
			}
		}

		public string Filter
		{
			get
			{
				return this.filter;
			}
			set
			{
				this.filter = value;
			}
		}

		public DeviceSpecific Owner
		{
			get
			{
				return this.owner;
			}
			set
			{
				this.owner = value;
			}
		}

		public IDictionary Templates
		{
			get
			{
				if(this.templates == null)
				{
					this.templates = new ListDictionary(caseInsensitiveComparer);
				}
				return this.templates;
			}
		}

		internal void ApplyProperties()
		{
			IDictionaryEnumerator ide = Contents.GetEnumerator();
			while(ide.MoveNext())
			{
				object owner = Owner.Owner;
				string key = (string)ide.Key;
				string value = (string)ide.Value;
				if(key.ToLower() == "id")
				{
					//FIXME
					throw new ArgumentException("DeviceSpecificChoice" +
					                            "_InvalidPropertyOverride");
				}
				if(value != null)
				{
					int dash = 0;
					while((dash = key.IndexOf('-')) != -1)
					{
						string first = key.Substring(0, dash);
						PropertyDescriptor pd =
						             TypeDescriptor.GetProperties(owner).Find(key, true);
						if(pd == null)
						{
							//FIXME
							throw new ArgumentException("DeviceSpecificChoice" +
							                            "_OverridingPropertyNotFound");
						}
						owner = pd.GetValue(owner);
						key = key.Substring(dash + 1);
					}
					if(!FindAndApplyProperty(owner, key, value) &&
					   !FindAndApplyEvent(owner, key, value))
					{
						if(owner is IAttributeAccessor)
						{
							((IAttributeAccessor)owner).SetAttribute(key, value);
						} else
						{
							//FIXME
							throw new ArgumentException("DeviceSpecificChoice" +
							                            "_OverridingPropertyNotFound");
						}
					}
				}
			}
		}

		private bool FindAndApplyProperty(object parentObj, string key,
		                                  string value)
		{
			throw new NotImplementedException();
		}

		private bool FindAndApplyEvent(object parentObj, string key,
		                               string value)
		{
			throw new NotImplementedException();
		}

		private bool CheckOnPageEvaluator(MobileCapabilities capabilities,
		                                  out bool evaluatorResult)
		{
			throw new NotImplementedException();
		}
	}
}
