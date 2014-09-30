//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Reflection;
using FX.Configuration.Resolvers;

namespace FX.Configuration.Tests
{
    /// <summary>
    /// A custom setting name resolver
    /// </summary>
    public class CustomSettingNameResolver : ISettingNameResolver
    {
        /// <summary>
        /// Gets the name of the setting
        /// </summary>
        /// <typeparam name="T">The type of the configuration</typeparam>
        /// <param name="property">The property</param>
        /// <returns>The setting name</returns>
        public string GetSettingName(PropertyInfo property)
        {
            return "custom-prefix-" + property.Name;
        }
    }
}