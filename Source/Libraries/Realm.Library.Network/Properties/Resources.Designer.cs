﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Realm.Library.Network.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Realm.Library.Network.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TcpUser was not found.
        /// </summary>
        internal static string ERR_NO_TCPUSER {
            get {
                return ResourceManager.GetString("ERR_NO_TCPUSER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter is null.
        /// </summary>
        internal static string ERR_NULL_PARAMETER {
            get {
                return ResourceManager.GetString("ERR_NULL_PARAMETER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 127.0.0.1.
        /// </summary>
        internal static string LOCALHOST_IP {
            get {
                return ResourceManager.GetString("LOCALHOST_IP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Connection Lost from {0}.
        /// </summary>
        internal static string MSG_CONNECTION_LOST {
            get {
                return ResourceManager.GetString("MSG_CONNECTION_LOST", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TcpServer Listening on {0}.
        /// </summary>
        internal static string MSG_TCPSERVER_LISTEN {
            get {
                return ResourceManager.GetString("MSG_TCPSERVER_LISTEN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TcpServer starting up on port {0}.
        /// </summary>
        internal static string MSG_TCPSERVER_START {
            get {
                return ResourceManager.GetString("MSG_TCPSERVER_START", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Listener Thread state {0}.
        /// </summary>
        internal static string MSG_TCPSERVER_STATE {
            get {
                return ResourceManager.GetString("MSG_TCPSERVER_STATE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TcpServer Shutdown..
        /// </summary>
        internal static string MSG_TCPSERVER_STOP {
            get {
                return ResourceManager.GetString("MSG_TCPSERVER_STOP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TcpClient[{0}, {1}] connected..
        /// </summary>
        internal static string MSG_TCPUSER_CONNECT {
            get {
                return ResourceManager.GetString("MSG_TCPUSER_CONNECT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Client[{0}, {1}] disconnected..
        /// </summary>
        internal static string MSG_TCPUSER_DISCONNECT {
            get {
                return ResourceManager.GetString("MSG_TCPUSER_DISCONNECT", resourceCulture);
            }
        }
    }
}