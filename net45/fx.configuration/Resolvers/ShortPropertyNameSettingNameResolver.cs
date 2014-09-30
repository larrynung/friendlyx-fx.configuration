//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System.Reflection;

namespace FX.Configuration.Resolvers
{
    /// <summary>
    /// A setting name resolver which returns a setting name as a name of a property
    /// </summary>
    public class ShortPropertyNameSettingNameResolver : ISettingNameResolver
    {
        /// <summary>
        /// Gets the name of the setting
        /// </summary>
        /// <param name="property">The property</param>
        /// <returns>A setting name</returns>
        public string GetSettingName(PropertyInfo property)
        {
            return property.Name;
        }
    }
}
