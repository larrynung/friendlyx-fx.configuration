//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using FX.Configuration.Resolvers;

namespace FX.Configuration
{
    /// <summary>
    /// A configuration provider reading settings from an app configuration file
    /// </summary>
    public class AppConfigurationProvider : BaseConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationProvider"/> class.
        /// </summary>
        public AppConfigurationProvider()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationProvider"/> class.
        /// </summary>
        /// <param name="settingsDeserializers">The settings deserializers</param>
        public AppConfigurationProvider(IEnumerable<object> settingsDeserializers)
            : base(settingsDeserializers)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationProvider" /> class.
        /// </summary>
        /// <param name="settingNameResolver">The setting name resolver.</param>
        public AppConfigurationProvider(ISettingNameResolver settingNameResolver)
            : base(settingNameResolver)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationProvider" /> class.
        /// </summary>
        /// <param name="settingsDeserializers">The settings deserializers</param>
        /// <param name="settingNameResolver">The setting name resolver</param>
        public AppConfigurationProvider(IEnumerable<object> settingsDeserializers, ISettingNameResolver settingNameResolver)
            : base(settingsDeserializers, settingNameResolver)
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