//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace FX.Configuration.Tests
{
    /// <summary>
    /// A custom configuration provider
    /// </summary>
    internal class CustomCultureAppConfigurationProvider : AppConfigurationProvider
    {
        /// <summary>
        /// Gets the deserialized value
        /// </summary>
        /// <param name="deserializers">The deserializers</param>
        /// <param name="property">The property</param>
        /// <param name="rawSetting">The raw setting</param>
        /// <returns>The value</returns>
        protected override object GetDeserializedValue(IEnumerable<object> deserializers, PropertyInfo property, object rawSetting)
        {
            object result;
            if (property.Name == "DecimalPropertyInCustomCulture")
            {
                result = Convert.ToDecimal(rawSetting, new CultureInfo("ru-RU"));
            }
            else
            {
                result = base.GetDeserializedValue(deserializers, property, rawSetting);
            }

            return result;
        }
    }
}