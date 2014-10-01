/* The MIT License (MIT)
*
* Copyright (c) 2014 FriendlyX
* Permission is hereby granted, free of charge, to any person obtaining a copy of
* this software and associated documentation files (the "Software"), to deal in
* the Software without restriction, including without limitation the rights to
* use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
* the Software, and to permit persons to whom the Software is furnished to do so,
* subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
* FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
* COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
* IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
* CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

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