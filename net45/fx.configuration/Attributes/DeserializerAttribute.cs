//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;

namespace FX.Configuration.Attributes
{
    /// <summary>
    /// Defines what type of deserializer to use
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DeserializerAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeserializerAttribute"/> class.
        /// </summary>
        /// <param name="deserializerType">Type of the deserializer.</param>
        public DeserializerAttribute(Type deserializerType)
        {
            this.DeserializerType = deserializerType;
        }
        /// <summary>
        /// Gets the type of the deserializer
        /// </summary>
        public Type DeserializerType { get; private set; }
    }
}