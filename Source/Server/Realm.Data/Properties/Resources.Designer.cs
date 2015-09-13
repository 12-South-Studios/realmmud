﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Realm.Data.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Realm.Data.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Command {0} not found in table for Loader {1}..
        /// </summary>
        internal static string ERR_CMD_NOT_FOUND {
            get {
                return ResourceManager.GetString("ERR_CMD_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to find a Database Server for Transaction {0}.
        /// </summary>
        internal static string ERR_DB_SERVER_NOT_FOUND {
            get {
                return ResourceManager.GetString("ERR_DB_SERVER_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Manager {0} failed to initialize..
        /// </summary>
        internal static string ERR_FAIL_INITIALIZE_MANAGER {
            get {
                return ResourceManager.GetString("ERR_FAIL_INITIALIZE_MANAGER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Atom {0} could not be cast to a DictionaryAtom.
        /// </summary>
        internal static string ERR_INVALID_CAST {
            get {
                return ResourceManager.GetString("ERR_INVALID_CAST", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failure to load data in {0}.
        /// </summary>
        internal static string ERR_LOADER_FAILURE {
            get {
                return ResourceManager.GetString("ERR_LOADER_FAILURE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Primitive {0} not found..
        /// </summary>
        internal static string ERR_PRIMITIVE_NOT_FOUND {
            get {
                return ResourceManager.GetString("ERR_PRIMITIVE_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Initialized Database Server Context with {0} server objects..
        /// </summary>
        internal static string MSG_INIT_SERVER_CONTEXT {
            get {
                return ResourceManager.GetString("MSG_INIT_SERVER_CONTEXT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Manager {0} initialized..
        /// </summary>
        internal static string MSG_INITIALIZE_MANAGER {
            get {
                return ResourceManager.GetString("MSG_INITIALIZE_MANAGER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT PARAMETER_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, PARAMETER_MODE FROM INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME = &apos;@ProcName&apos; ORDER BY ORDINAL_POSITION.
        /// </summary>
        internal static string SQL_PARAMETER_QUERY {
            get {
                return ResourceManager.GetString("SQL_PARAMETER_QUERY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT SPECIFIC_NAME FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = &apos;PROCEDURE&apos; AND SPECIFIC_CATALOG = &apos;@Catalog&apos; AND SPECIFIC_SCHEMA = &apos;@Schema&apos; AND SPECIFIC_NAME LIKE &apos;@SpecificName%&apos; ORDER BY ROUTINE_NAME.
        /// </summary>
        internal static string SQL_PROCEDURE_QUERY {
            get {
                return ResourceManager.GetString("SQL_PROCEDURE_QUERY", resourceCulture);
            }
        }
    }
}
