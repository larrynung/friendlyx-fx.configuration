//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Reflection;
using FX.Configuration.Resolvers;

namespace FX.Configuration.ConsoleSample
{
    /// <summary>
    /// A custom setting name configuration resolver
    /// </summary>
    public class CustomSettingNameResolver : ISettingNameResolver
    {
        /// <summary>
        /// Gets the name of the setting
        /// </summary>
        /// <param name="property">The property</param>
        /// <returns>The setting name</returns>
        public string GetSettingName(PropertyInfo property)
        {
            return "Custom." + property.Name;
        }
    }
}