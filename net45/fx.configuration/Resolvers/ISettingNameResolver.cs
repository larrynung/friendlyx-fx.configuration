//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System.Reflection;

namespace FX.Configuration.Resolvers
{
    /// <summary>
    /// A setting name resolver
    /// </summary>
    public interface ISettingNameResolver
    {
        /// <summary>
        /// Gets the name of the setting
        /// </summary>
        /// <param name="property">The property</param>
        /// <returns>A setting name</returns>
        string GetSettingName(PropertyInfo property);
    }
}