//
// System.Configuration.HttpConfigurationSystem.cs
//
// Authors:
//  Chris Toshok (toshok@ximian.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (C) 2006 Novell, Inc (http://www.novell.com)
//


using System;
using System.IO;
using System.Reflection;
using System.Configuration.Internal;
using _Configuration = System.Configuration;

namespace System.Web.Configuration {

internal class MyRecord : IInternalConfigRecord
	{
		public object GetLkgSection (string configKey)
		{
			return null;
		}

		public object GetSection(string configKey) {
            if (configKey == "system.web/pages") {
                var configMap = new _Configuration.ExeConfigurationFileMap();
                configMap.ExeConfigFilename = HttpConfigurationSystem.RootWebConfigurationFilePath;
                var config = _Configuration.ConfigurationManager.OpenMappedExeConfiguration(configMap, _Configuration.ConfigurationUserLevel.None);

                return (PagesSection)config.GetSection(configKey);
            }


			return null;
		}

		public void RefreshSection (string configKey)
		{
			
		}

		public void Remove ()
		{
			
		}

		public void ThrowIfInitErrors ()
		{
			
		}
		string _configPath;
		public string ConfigPath { get { return _configPath; } internal set { _configPath = value; }}

		public bool HasInitErrors { get { return false; } }

		public string StreamName { get { return null; } }


	}

	internal class HttpConfigurationSystem : IInternalConfigSystem
	{
		object IInternalConfigSystem.GetSection (string configKey)
		{
			return WebConfigurationManager.GetSection (configKey);
		}

		void IInternalConfigSystem.RefreshConfig (string sectionName)
		{
		}

		bool IInternalConfigSystem.SupportsUserConfig {
			get { return true; }
		}
        static internal bool IsSet {
            get {
                return true;
            }
        }
		internal static bool UseHttpConfigurationSystem {
			get { return true; }
		}
		
		        static internal IInternalConfigRecord GetUniqueConfigRecord(string configPath) {
			return new MyRecord(){ConfigPath=configPath};
        }

		static internal void CompleteInit(){
}
        
		internal const string MachineConfigFilename = "machine.config";
        internal const string RootWebConfigFilename         = "web.config";
        internal const string WebConfigFileName             = "web.config";

        static private string                           s_MachineConfigurationDirectory;
        static private string                           s_MachineConfigurationFilePath;
        static private string                           s_RootWebConfigurationFilePath;
        static private string                           s_MsCorLibDirectory;

        static internal string MachineConfigurationDirectory {
            get {
                if (s_MachineConfigurationDirectory == null) {
                    s_MachineConfigurationDirectory = Path.GetDirectoryName(System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile);
                }

                return s_MachineConfigurationDirectory;
            }
        }

        static internal string MachineConfigurationFilePath {
            get {
                if (s_MachineConfigurationFilePath == null) {
                    s_MachineConfigurationFilePath = Path.Combine(MachineConfigurationDirectory, MachineConfigFilename);
                }

                return s_MachineConfigurationFilePath;
            }
        }

        static internal string RootWebConfigurationFilePath {
            get {
                if (s_RootWebConfigurationFilePath == null) {
                    s_RootWebConfigurationFilePath = Path.Combine(MachineConfigurationDirectory, RootWebConfigFilename);
                }

                return s_RootWebConfigurationFilePath;
            }
            set { }
        }

        static internal String MsCorLibDirectory {
            get {
                if (s_MsCorLibDirectory == null) {
                    s_MsCorLibDirectory = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
                }

                return s_MsCorLibDirectory;
            }
        }
        static internal void EnsureInit(IConfigMapPath configMapPath, bool listenToFileChanges, bool initComplete) {
		}
		
        static internal void AddFileDependency(String file) {}
	}
}

