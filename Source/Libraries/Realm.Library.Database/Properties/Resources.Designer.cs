﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Realm.Library.Database.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Realm.Library.Database.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Db Procedure {0}.{1} not found..
        /// </summary>
        internal static string ERR_DB_PROC_NOT_FOUND {
            get {
                return ResourceManager.GetString("ERR_DB_PROC_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction Id was invalid.
        /// </summary>
        internal static string ERR_INVALID_TRANS_ID {
            get {
                return ResourceManager.GetString("ERR_INVALID_TRANS_ID", resourceCulture);
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
        ///   Looks up a localized string similar to Pending Transaction {0} not found..
        /// </summary>
        internal static string ERR_PENDING_TRANS_NOT_FOUND {
            get {
                return ResourceManager.GetString("ERR_PENDING_TRANS_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Referenced an unsupported DbType.
        /// </summary>
        internal static string ERR_UNSUPPORTED_DBTYPE {
            get {
                return ResourceManager.GetString("ERR_UNSUPPORTED_DBTYPE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Referenced an unsupported SqlDbType.
        /// </summary>
        internal static string ERR_UNSUPPORTED_SQLTYPE {
            get {
                return ResourceManager.GetString("ERR_UNSUPPORTED_SQLTYPE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Referenced an unsupported Type.
        /// </summary>
        internal static string ERR_UNSUPPORTED_TYPE {
            get {
                return ResourceManager.GetString("ERR_UNSUPPORTED_TYPE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}:{1}[{2}].
        /// </summary>
        internal static string MSG_PROC_TOSTRING {
            get {
                return ResourceManager.GetString("MSG_PROC_TOSTRING", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction {0} cancelled..
        /// </summary>
        internal static string MSG_TRANS_CANCELLED {
            get {
                return ResourceManager.GetString("MSG_TRANS_CANCELLED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction {0} completed. Status {1}.
        /// </summary>
        internal static string MSG_TRANS_COMPLETE {
            get {
                return ResourceManager.GetString("MSG_TRANS_COMPLETE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Transaction {0} submitted..
        /// </summary>
        internal static string MSG_TRANS_SUBMIT {
            get {
                return ResourceManager.GetString("MSG_TRANS_SUBMIT", resourceCulture);
            }
        }
    }
}
