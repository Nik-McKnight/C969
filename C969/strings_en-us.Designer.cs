﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace C969 {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class strings_en_us {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal strings_en_us() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("C969.strings_en-us", typeof(strings_en_us).Assembly);
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
        ///   Looks up a localized string similar to Log In.
        /// </summary>
        internal static string LOGIN {
            get {
                return ResourceManager.GetString("LOGIN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Incorrect username or password.
        /// </summary>
        internal static string LOGINFALSE {
            get {
                return ResourceManager.GetString("LOGINFALSE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Logged in.
        /// </summary>
        internal static string LOGINTRUE {
            get {
                return ResourceManager.GetString("LOGINTRUE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter Password.
        /// </summary>
        internal static string PASSWORD {
            get {
                return ResourceManager.GetString("PASSWORD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Username already exists.
        /// </summary>
        internal static string REGISTERFALSE {
            get {
                return ResourceManager.GetString("REGISTERFALSE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Created user.
        /// </summary>
        internal static string REGISTERTRUE {
            get {
                return ResourceManager.GetString("REGISTERTRUE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter Username.
        /// </summary>
        internal static string USERNAME {
            get {
                return ResourceManager.GetString("USERNAME", resourceCulture);
            }
        }
    }
}