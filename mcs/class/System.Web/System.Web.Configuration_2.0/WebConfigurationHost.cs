//
// System.Web.Configuration.WebConfigurationHost.cs
//
// Authors:
//  Lluis Sanchez Gual (lluis@novell.com)
//  Marek Habersack <mhabersack@novell.com>
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
// Copyright (C) 2005-2009 Novell, Inc (http://www.novell.com)
//


using System;
using System.Collections;
using System.IO;
using System.Security;
using System.Configuration;
using System.Configuration.Internal;
using System.Web.Hosting;
using System.Web.Util;
using System.Reflection;

/*
 * this class needs to be rewritten to support usage of the
 * IRemoteWebConfigurationHostServer interface.  Once that's done, we
 * need an implementation of that interface that talks (through a web
 * service?) to a remote site..
 *
 * for now, though, just implement it as we do
 * System.Configuration.InternalConfigurationHost, i.e. the local
 * case.
 */
namespace System.Web.Configuration
{
	class WebConfigurationHost: IInternalConfigHost
	{

        internal const char             PathSeparator = '/';
        internal const string           DefaultSiteID = "1";
        private static string                               s_defaultSiteName;

        internal const string           MachineConfigPath = MachinePath;
        internal const string           RootWebConfigPath = MachineWebPath;
        private static readonly string  RootWebConfigPathAndPathSeparator = RootWebConfigPath + PathSeparator;
        private static readonly string  RootWebConfigPathAndDefaultSiteID = RootWebConfigPathAndPathSeparator + DefaultSiteID;

        static internal string GetConfigPathFromSiteIDAndVPath(string siteID, VirtualPath vpath) {
#if DBG
            // Do not inadverte expand app-relative paths using appdomain
            Debug.Assert(vpath == null || vpath.VirtualPathStringIfAvailable != null || vpath.AppRelativeVirtualPathStringIfAvailable == null,
                        "vpath == null || vpath.VirtualPathStringIfAvailable != null || vpath.AppRelativeVirtualPathStringIfAvailable == null");
#endif

            if (vpath == null || string.IsNullOrEmpty(siteID)) {
                return RootWebConfigPath;
            }

            string virtualPath = vpath.VirtualPathStringNoTrailingSlash.ToLower(System.Globalization.CultureInfo.InvariantCulture);
            string configPath = (siteID == DefaultSiteID) ? RootWebConfigPathAndDefaultSiteID : RootWebConfigPathAndPathSeparator + siteID;
            if (virtualPath.Length > 1) {
                configPath += virtualPath;
            }
            return configPath;
        }



        static internal bool IsMachineConfigPath(string configPath) {
            return configPath.Length == MachineConfigPath.Length;
        }

        static internal bool IsRootWebConfigPath(string configPath) {
            return configPath.Length == RootWebConfigPath.Length;
        }

        // Does the configPath represent a virtual path?
        static internal bool IsVirtualPathConfigPath(string configPath) {
            return configPath.Length > RootWebConfigPath.Length;
        }



      static internal string DefaultSiteName {
            get {
                if (s_defaultSiteName == null) {
                    s_defaultSiteName = SR.GetString(SR.DefaultSiteName);
                }
 
                return s_defaultSiteName;
            }
        }

        // A site argument that begins or ends in slashes will prevent
        // us from using it in a configPath
        static internal bool IsValidSiteArgument(string site) {
            if (!String.IsNullOrEmpty(site)) {
                char first = site[0];
                char last = site[site.Length - 1];

                if (first == '/' || first == '\\' || last == '/' || last == '\\') {
                    return false;
                }
            }

            return true;
        }

        internal static void StaticGetRestrictedPermissions(IInternalConfigRecord configRecord, out PermissionSet permissionSet, out bool isHostReady) {
            isHostReady = HttpRuntime.IsTrustLevelInitialized;
            permissionSet = null;
            if (isHostReady && IsVirtualPathConfigPath(configRecord.ConfigPath)) {
                permissionSet = HttpRuntime.NamedPermissionSet;
            }
        }

        // Not used in runtime because in runtime we have all the siteid, appPath, etc. already.
        static internal void GetConfigPaths(IConfigMapPath configMapPath, WebLevel webLevel, VirtualPath virtualPath, string site, string locationSubPath,
                out VirtualPath appPath, out string appSiteName, out string appSiteID, out string configPath, out string locationConfigPath) {
            throw new NotImplementedException();
}



        static internal void GetSiteIDAndVPathFromConfigPath(string configPath, out string siteID, out VirtualPath vpath) {
            if (!IsVirtualPathConfigPath(configPath)) {
                siteID = null;
                vpath = null;
                return;
            }

            int indexStart = RootWebConfigPath.Length + 1;
            int indexVPath = configPath.IndexOf(PathSeparator, indexStart);
            int length;
            if (indexVPath == -1) {
                length = configPath.Length - indexStart;
            }
            else {
                length = indexVPath - indexStart;
            }

            siteID = configPath.Substring(indexStart, length);
            if (indexVPath == -1) {
                vpath = VirtualPath.RootVirtualPath;
            }
            else {
                vpath = VirtualPath.CreateAbsolute(configPath.Substring(indexVPath));
            }
        }


		WebConfigurationFileMap map;
		const string MachinePath = "machine";
		const string MachineWebPath = "machine/webroot";

		string appVirtualPath;
		
		public virtual object CreateConfigurationContext (string configPath, string locationSubPath)
		{

           string              path;
            WebApplicationLevel pathLevel;
 
            path      = VPathFromConfigPath(configPath);
            pathLevel = WebApplicationLevel.AtApplication;
 
            return new WebContext( pathLevel,         // PathLevel
                                   System.Web.Hosting.HostingEnvironment.SiteNameNoDemand,      // Site
                                   System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath,          // AppPath
                                   path,              // Path
                                   locationSubPath,   // LocationSubPath
                                   configPath);   // e.g., "machine/webroot/2/approot"
		}

        // Return the virtual path from the configPath.
        static internal string VPathFromConfigPath(string configPath) {
            if (!IsVirtualPathConfigPath(configPath))
                return null;
 
            // Return the path part after [SiteName]
            int indexStart = RootWebConfigPath.Length + 1;
            int indexVPath = configPath.IndexOf(PathSeparator, indexStart);
            if (indexVPath == -1) {
                return "/";
            }
 
            return configPath.Substring(indexVPath);
        }
 
		public virtual object CreateDeprecatedConfigContext (string configPath)
		{
			return new HttpConfigurationContext(configPath);
		}
		
		public virtual string DecryptSection (string encryptedXml, ProtectedConfigurationProvider protectionProvider, ProtectedConfigurationSection protectedSection)
		{
			if (protectedSection == null)
				throw new ArgumentNullException ("protectedSection");

            throw new NotImplementedException();//return protectedSection.EncryptSection (encryptedXml, protectionProvider);
		}
		
		public virtual void DeleteStream (string streamName)
		{
			File.Delete (streamName);
		}
		
		public virtual string EncryptSection (string clearXml, ProtectedConfigurationProvider protectionProvider, ProtectedConfigurationSection protectedSection)
		{
			if (protectedSection == null)
				throw new ArgumentNullException ("protectedSection");

			throw new NotImplementedException();//return protectedSection.EncryptSection (clearXml, protectionProvider);
		}
		
		public virtual string GetConfigPathFromLocationSubPath (string configPath, string locationSubPath)
		{
			if (!String.IsNullOrEmpty (locationSubPath) && !String.IsNullOrEmpty (configPath)) {
				string relConfigPath = configPath.Length == 1 ? null : configPath.Substring (1) + "/";
				if (relConfigPath != null && locationSubPath.StartsWith (relConfigPath, StringComparison.Ordinal))
					locationSubPath = locationSubPath.Substring (relConfigPath.Length);
			}
			
			string ret = configPath + "/" + locationSubPath;
			if (!String.IsNullOrEmpty (ret) && ret [0] == '/')
				return ret.Substring (1);
			
			return ret;
		}
		

		public virtual Type GetConfigType (string typeName, bool throwOnError)
		{
		    //HttpApplication.LoadType (typeName);
			//if (type == null && throwOnError)
			//	throw new ConfigurationErrorsException ("Type not found: '" + typeName + "'");
			//return type;
            return System.Web.Compilation.BuildManager.GetType(typeName, throwOnError);
		}
		
		public virtual string GetConfigTypeName (Type t)
		{
			//return t.AssemblyQualifiedName;
            return System.Web.Compilation.BuildManager.GetNormalizedTypeName(t);
		}
		
		public virtual void GetRestrictedPermissions (IInternalConfigRecord configRecord, out PermissionSet permissionSet,
							      out bool isHostReady)
		{
			throw new NotImplementedException ();
		}
		
		public virtual string GetStreamName (string configPath)
		{
			if (configPath == MachinePath) {
				if (map == null)
					return System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile;
				else
					return map.MachineConfigFilename;
			} else if (configPath == MachineWebPath) {
				string mdir;

				if (map == null)
					mdir = Path.GetDirectoryName (System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile);
				else
					mdir = Path.GetDirectoryName (map.MachineConfigFilename);

				return GetWebConfigFileName (mdir);
			}
			
			string dir = MapPath (configPath);
			return GetWebConfigFileName (dir);
		}
		
		public virtual string GetStreamNameForConfigSource (string streamName, string configSource)
		{
			throw new NotImplementedException ();
		}
		
		public virtual object GetStreamVersion (string streamName)
		{
			throw new NotImplementedException ();
		}
		
		public virtual IDisposable Impersonate ()
		{
			throw new NotImplementedException ();
		}


		public virtual void Init (IInternalConfigRoot root, params object[] hostInitParams)
		{
        }
		
		public virtual void InitForConfiguration (ref string locationSubPath, out string configPath,
							  out string locationConfigPath, IInternalConfigRoot root,
							  params object[] hostInitConfigurationParams)
		{
			string fullPath = (string) hostInitConfigurationParams [1];
			map = (WebConfigurationFileMap) hostInitConfigurationParams [0];
			bool inAnotherApp = (bool) hostInitConfigurationParams [7];

			if (inAnotherApp)
				appVirtualPath = fullPath;
			else
				appVirtualPath = HttpRuntime.AppDomainAppVirtualPath;
			
			if (locationSubPath == MachineWebPath) {
				locationSubPath = MachinePath;
				configPath = MachineWebPath;
				locationConfigPath = null;
			} else if (locationSubPath == MachinePath) {
				locationSubPath = null;
				configPath = MachinePath;
				locationConfigPath = null;
			} else {
				int i;
				if (locationSubPath == null) {
					configPath = fullPath;
					if (configPath.Length > 1)
						configPath = VirtualPathUtility.RemoveTrailingSlash (configPath);
				} else
					configPath = locationSubPath;
				
				if (configPath == HttpRuntime.AppDomainAppVirtualPath || configPath == "/")
					i = -1;
				else
					i = configPath.LastIndexOf ("/");

				if (i != -1) {
					locationConfigPath = configPath.Substring (i+1);
					
					if (i == 0)
						locationSubPath = "/";
					else
						locationSubPath = fullPath.Substring (0, i);
				} else {
					locationSubPath = MachineWebPath;
					locationConfigPath = null;
				}
			}
		}
		internal const string FAKE_VIRTUAL_PATH_PREFIX = "/@@MonoFakeVirtualPath@@";
		public string MapPath (string virtualPath)
		{
			if (!String.IsNullOrEmpty (virtualPath)) {
				if (virtualPath.StartsWith (FAKE_VIRTUAL_PATH_PREFIX, StringComparison.Ordinal))
					return HttpRuntime.AppDomainAppPath;
			}
			
			if (map != null)
				return MapPathFromMapper (virtualPath);
			else if (HttpContext.Current != null && HttpContext.Current.Request != null)
				return HttpContext.Current.Request.MapPath (virtualPath);
			else if (HttpRuntime.AppDomainAppVirtualPath != null &&
				 virtualPath.StartsWith (HttpRuntime.AppDomainAppVirtualPath)) {
				if (virtualPath == HttpRuntime.AppDomainAppVirtualPath)
					return HttpRuntime.AppDomainAppPath;
				return UrlUtils.Combine (HttpRuntime.AppDomainAppPath,
					virtualPath.Substring (HttpRuntime.AppDomainAppVirtualPath.Length));
			}
			
			return virtualPath;
		}
		
		public string NormalizeVirtualPath (string virtualPath)
		{
			if (virtualPath == null || virtualPath.Length == 0)
				virtualPath = ".";
			else
				virtualPath = virtualPath.Trim ();

			if (virtualPath [0] == '~' && virtualPath.Length > 2 && virtualPath [1] == '/')
				virtualPath = virtualPath.Substring (1);
				
			if (System.IO.Path.DirectorySeparatorChar != '/')
				virtualPath = virtualPath.Replace (System.IO.Path.DirectorySeparatorChar, '/');

			if (UrlUtils.IsRooted (virtualPath)) {
				virtualPath = UrlUtils.Canonic (virtualPath);
			} else {
				if (map.VirtualDirectories.Count > 0) {
					string root = map.VirtualDirectories [0].VirtualDirectory;
					virtualPath = UrlUtils.Combine (root, virtualPath);
					virtualPath = UrlUtils.Canonic (virtualPath);
				}
			}

			return virtualPath;
		}

		public string MapPathFromMapper (string virtualPath)
		{
			string path = NormalizeVirtualPath (virtualPath);
			
			foreach (VirtualDirectoryMapping mapping in map.VirtualDirectories) {
				if (path.StartsWith (mapping.VirtualDirectory)) {
					int i = mapping.VirtualDirectory.Length;
					if (path.Length == i) {
						return mapping.PhysicalDirectory;
					}
					else if (path [i] == '/') {
						string pathPart = path.Substring (i + 1).Replace ('/', Path.DirectorySeparatorChar);
						return Path.Combine (mapping.PhysicalDirectory, pathPart);
					}
				}
			}
			throw new HttpException ("Invalid virtual directory: " + virtualPath);
		}

        internal static string FindWebConfig (string basedir) 
      { 
          if (String.IsNullOrEmpty (basedir) || !Directory.Exists (basedir)) 
              return null; 
 

          string[] files = Directory.GetFileSystemEntries (basedir, "?eb.?onfig"); 
          if (files == null || files.Length == 0) 
              return null; 
          return files [0]; 
      } 
  

		internal static string GetWebConfigFileName (string dir)
		{
			AppDomain domain = AppDomain.CurrentDomain;
            bool hosted = true;//(domain.GetData (""/*REVTODO: ApplicationHost.MonoHostedDataKey*/) as string) == "yes";

			if (hosted)
				return FindWebConfig (dir);
			else {
				Assembly asm = Assembly.GetEntryAssembly () ?? Assembly.GetCallingAssembly ();
				string name = Path.GetFileName (asm.Location);
				string[] fileNames = new string[] {name + ".config", name + ".Config"};
				string appDir = domain.BaseDirectory;
				string file;

				foreach (string fn in fileNames) {
					file = Path.Combine (appDir, fn);
					if (File.Exists (file))
						return file;
				}
			}
			return null;
		}
		public virtual bool IsAboveApplication (string configPath)
		{
			return !configPath.Contains (HttpRuntime.AppDomainAppPath);
		}
		
		public virtual bool IsConfigRecordRequired (string configPath)
		{
			throw new NotImplementedException ();
		}
		
		public virtual bool IsDefinitionAllowed (string configPath, ConfigurationAllowDefinition allowDefinition,
							 ConfigurationAllowExeDefinition allowExeDefinition)
		{
			switch (allowDefinition) {
				case ConfigurationAllowDefinition.MachineOnly:
					return configPath == MachinePath || configPath == MachineWebPath;
				case ConfigurationAllowDefinition.MachineToWebRoot:
				case ConfigurationAllowDefinition.MachineToApplication:
					if (String.IsNullOrEmpty (configPath))
						return true;
					string normalized;

					if (VirtualPathUtility.IsAbsolute (configPath) || VirtualPathUtility.IsAppRelative (configPath))
						normalized = VirtualPathUtility.Normalize (configPath);
					else
						normalized = configPath;
					
					if ((String.Compare (normalized, MachinePath, StringComparison.Ordinal) == 0) ||
						(String.Compare (normalized, MachineWebPath, StringComparison.Ordinal) == 0))
							return true;
				
					if ((String.Compare (normalized, appVirtualPath) != 0))
						return IsApplication (normalized);
				
					return true;
				default:
					return true;
			}
		}
		
		[MonoTODO("Should return false in case strPath points to the root of an application.")]
		internal bool IsApplication(string strPath)
		{
			return true;
		}
		
		public virtual bool IsFile (string streamName)
		{
			throw new NotImplementedException ();
		}
		
		public virtual bool IsLocationApplicable (string configPath)
		{
			throw new NotImplementedException ();
		}
		
		public virtual Stream OpenStreamForRead (string streamName)
		{
			if (!File.Exists (streamName)) {
				return null;
			}
				
			return new FileStream (streamName, FileMode.Open, FileAccess.Read);
		}

		[MonoTODO ("Not implemented")]
		public virtual Stream OpenStreamForRead (string streamName, bool assertPermissions)
		{
			throw new NotImplementedException ();
		}

		public virtual Stream OpenStreamForWrite (string streamName, string templateStreamName, ref object writeContext)
		{
			if (!IsAboveApplication (streamName))
				WebConfigurationManager.SuppressAppReload (true);

			return new FileStream (streamName, FileMode.Create, FileAccess.Write);
		}

		[MonoTODO ("Not implemented")]
		public virtual Stream OpenStreamForWrite (string streamName, string templateStreamName, ref object writeContext,
							  bool assertPermissions)
		{
			throw new NotImplementedException ();
		}
		
		public virtual bool PrefetchAll (string configPath, string streamName)
		{
			throw new NotImplementedException ();
		}
		
		public virtual bool PrefetchSection (string sectionGroupName, string sectionName)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO ("Not implemented")]
		public virtual void RequireCompleteInit (IInternalConfigRecord configRecord)
		{
			throw new NotImplementedException ();
		}

		public virtual object StartMonitoringStreamForChanges (string streamName, StreamChangeCallback callback)
		{			
			throw new NotImplementedException ();
		}
		
		public virtual void StopMonitoringStreamForChanges (string streamName, StreamChangeCallback callback)
		{
			throw new NotImplementedException ();
		}
		
		public virtual void VerifyDefinitionAllowed (string configPath, ConfigurationAllowDefinition allowDefinition,
							     ConfigurationAllowExeDefinition allowExeDefinition,
							     IConfigErrorInfo errorInfo)
		{
			if (!IsDefinitionAllowed (configPath, allowDefinition, allowExeDefinition))
				throw new ConfigurationErrorsException ("The section can't be defined in this file (the allowed definition context is '" + allowDefinition + "').", errorInfo.Filename, errorInfo.LineNumber);
		}
		
		public virtual void WriteCompleted (string streamName, bool success, object writeContext)
		{
			WriteCompleted (streamName, success, writeContext, false);
		}		

		public virtual void WriteCompleted (string streamName, bool success, object writeContext, bool assertPermissions)
		{
			// There are probably other things to be done here, but for the moment we
			// just mark the completed write as one that should not cause application
			// reload. Note that it might already be too late for suppression, since the
			// FileSystemWatcher monitor might have already delivered the
			// notification. If the stream has been open using OpenStreamForWrite then
			// we're safe, though.

			if (!IsAboveApplication (streamName))
				WebConfigurationManager.SuppressAppReload (true);
		}

		public virtual bool SupportsChangeNotifications {
			get { return false; }
		}
		
		public virtual bool SupportsLocation {
			get { return false; }
		}
		
		public virtual bool SupportsPath {
			get { return false; }
		}
		
		public virtual bool SupportsRefresh {
			get { return false; }
		}

		[MonoTODO("Always returns false")]
		public virtual bool IsRemote {
			get { return false; }
		}

		[MonoTODO ("Not implemented")]
		public virtual bool IsFullTrustSectionWithoutAptcaAllowed (IInternalConfigRecord configRecord)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO ("Not implemented")]
		public virtual bool IsInitDelayed (IInternalConfigRecord configRecord)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO ("Not implemented")]
		public virtual bool IsSecondaryRoot (string configPath)
		{
			throw new NotImplementedException ();
		}

		[MonoTODO ("Not implemented")]
		public virtual bool IsTrustedConfigPath (string configPath)
		{
			throw new NotImplementedException ();
		}


	}
}

