//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using FX.Configuration.Deserializers;

namespace FX.Configuration.Attributes
{
    /// <summary>
    /// An attribute to define that the Json Deserializer should be used to deserialize the value
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class JsonSettingAttribute : DeserializerAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSettingAttribute"/> class.
        /// </summary>
        public JsonSettingAttribute()
            : base(typeof(JsonDeserializer))
        {
        }
    }
}