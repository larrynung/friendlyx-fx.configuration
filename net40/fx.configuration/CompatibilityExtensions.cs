//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;

namespace FX.Configuration
{
    /// <summary>
    /// Extension methods for .NET Framework compatibility
    /// </summary>
    internal static class CompatibilityExtensions
    {
        /// <summary>
        /// Gets the custom attributes
        /// </summary>
        /// <typeparam name="T">Type of the attribute</typeparam>
        /// <param name="element">The element</param>
        /// <returns>The list of custom attributes</returns>
        public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo element) where T : Attribute
        {
            return (IEnumerable<T>)GetCustomAttributes(element, typeof(T));
        }

        /// <summary>
        /// Gets the custom attributes
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="attributeType">Type of the attribute</param>
        /// <returns>The list of custom attributes</returns>
        public static IEnumerable<Attribute> GetCustomAttributes(this MemberInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttributes(element, attributeType);
        }

        /// <summary>
        /// Gets the custom attribute
        /// </summary>
        /// <typeparam name="T">Type of the attribute</typeparam>
        /// <param name="element">The element</param>
        /// <returns>The custom attribute</returns>
        public static T GetCustomAttribute<T>(this MemberInfo element) where T : Attribute
        {
            return (T)GetCustomAttribute(element, typeof(T));
        }

        /// <summary>
        /// Gets the custom attribute
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="attributeType">Type of the attribute</param>
        /// <returns>The custom attribute</returns>
        public static Attribute GetCustomAttribute(this MemberInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttribute(element, attributeType);
        }
    }
}