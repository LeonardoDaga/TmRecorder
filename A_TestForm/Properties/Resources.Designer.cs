﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace A_TestForm.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("A_TestForm.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to function get_players_training()
        ///{
        ///	strout = &quot;no data&quot;;
        ///
        ///	try
        ///	{
        ///		if (arrows == null) return &quot;Javascript error: arrows is null&quot;;
        ///		strout = &quot;&quot;;
        ///
        ///		// Get data from months
        ///		for (var i in arrows)
        ///		{
        ///			strout += &quot;player=&quot; + i + &quot;;&quot;;
        ///			strout += &quot;ti=&quot; + arrows[i].ti + &quot;;&quot;;
        ///			for (j = 0; j &lt; arrows[i].raise.length; j++)
        ///			{
        ///				strout += j + &quot;=&quot; + arrows[i].raise[j] + &quot;;&quot;;
        ///			}
        ///			strout += &quot;\n&quot;;
        ///		}
        ///	}
        ///	catch (err)
        ///	{
        ///		strout += &quot;;Javascript error = &quot; + err;
        ///	}
        ///	return strout;
        ///} [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string get_players_training_loader {
            get {
                return ResourceManager.GetString("get_players_training_loader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to function get_players()
        ///{
        ///	strout = &quot;no data&quot;;
        ///
        ///	ths = [&quot;id&quot;, &quot;no&quot;, &quot;name&quot;, &quot;age&quot;, &quot;fp&quot;, &quot;str&quot;, &quot;sta&quot;, &quot;pac&quot;, &quot;mar&quot;, &quot;tac&quot;, &quot;wor&quot;, &quot;pos&quot;, &quot;pas&quot;, &quot;cro&quot;, &quot;tec&quot;, &quot;hea&quot;, &quot;fin&quot;, &quot;lon&quot;, &quot;set&quot;, &quot;rec&quot;, &quot;rat&quot;, &quot;routine&quot;, &quot;wage&quot;, &quot;asi&quot;, &quot;inj&quot;, &quot;ban_points&quot;, &quot;retire&quot;, &quot;country&quot;, &quot;goals&quot;, &quot;assists&quot;, &quot;gp&quot;, &quot;cards&quot;, &quot;mom&quot;, &quot;club&quot;, &quot;txt&quot;, &quot;ban&quot;];
        ///	gk_ths = [&quot;id&quot;, &quot;no&quot;, &quot;name&quot;, &quot;age&quot;, &quot;fp&quot;, &quot;str&quot;, &quot;sta&quot;, &quot;pac&quot;, &quot;han&quot;, &quot;one&quot;, &quot;ref&quot;, &quot;ari&quot;, &quot;jum&quot;, &quot;com&quot;, &quot;kic&quot;, &quot;thr&quot;, &quot;rec&quot;, &quot;rat&quot;....
        /// </summary>
        internal static string players_loader {
            get {
                return ResourceManager.GetString("players_loader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to function ApplyRatingR2() {
        ///
        ///    var rou_factor = 0.00405;
        ///    var wage_rate = 27.55 * 0.9;
        ///
        ///    // Array to setup the weights of particular skills for each player&apos;s actual ability
        ///    // This is the direct weight to be given to each skill.
        ///    // Array maps to these skills:
        ///    //				   [Str,Sta,Pac,Mar,Tac,Wor,Pos,Pas,Cro,Tec,Hea,Fin,Lon,Set]
        ///    var positions = [[1, 3, 1, 1, 1, 3, 3, 2, 2, 2, 1, 3, 3, 3], // D C
        ///                     [2, 3, 1, 1, 1, 3, 3, 2, 2, 2, 2, 3, 3, 3], // D L
        ///            [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RatingR2_user {
            get {
                return ResourceManager.GetString("RatingR2_user", resourceCulture);
            }
        }
    }
}