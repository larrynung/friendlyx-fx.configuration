//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using FX.Configuration.Attributes;

namespace FX.Configuration
{
    /// <summary>
    /// Extention methods
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Gets the configuration environemnt attributes.
        /// </summary>
        /// <param name="configurationProvider">The configuration provider.</param>
        /// <returns>A list of ConfigurationEnvironmentAttribute</returns>
        public static IEnumerable<ConfigurationEnvironmentAttribute> GetConfigurationEnvironemntAttributes(this IConfigurationProvider configurationProvider)
        {
            return configurationProvider.GetType().GetCustomAttributes<ConfigurationEnvironmentAttribute>();
        }

        /// <summary>
        /// Gets the deserializer from the property attribute
        /// </summary>
        /// <param name="property">The property</param>
        /// <returns>The instance of a deserializer</returns>
        public static object GetDeserializerFromAttribute(this PropertyInfo property)
        {
            DeserializerAttribute attribute = property.GetCustomAttribute<DeserializerAttribute>();
            return attribute == null ? null : Activator.CreateInstance(attribute.DeserializerType);
        }

        /// <summary>
        /// Gets the culture information
        /// </summary>
        /// <param name="property">The property</param>
        /// <returns>A culture info</returns>
        public static CultureInfo GetCustomCultureInfo(this PropertyInfo property)
        {
            CustomCultureAttribute attribute = property.GetCustomAttribute<CustomCultureAttribute>();
            return attribute == null ? null : new CultureInfo(attribute.CultureCode);
        }
    }
}