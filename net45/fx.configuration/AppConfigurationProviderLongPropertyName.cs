//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;

namespace FX.Configuration
{
    /// <summary>
    /// A configuration provider reading settings from an app configuration file resolving setting keys based on short property names
    /// </summary>
    public class AppConfigurationProviderLongPropertyName : BaseConfigurationProviderLongPropertyName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationProvider"/> class.
        /// </summary>
        public AppConfigurationProviderLongPropertyName()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationProvider"/> class.
        /// </summary>
        /// <param name="settingsDeserializers">The settings deserializers</param>
        public AppConfigurationProviderLongPropertyName(IEnumerable<object> settingsDeserializers)
            : base(settingsDeserializers)
        {
        }

        /// <summary>
        /// Gets the value
        /// </summary>
        /// <param name="valueKey">The value key</param>
        /// <returns>The value</returns>
        public override object GetRawValue(string valueKey)
        {
            string stringValue = ConfigurationManager.AppSettings[valueKey];
            return stringValue;
        }
    }
}
