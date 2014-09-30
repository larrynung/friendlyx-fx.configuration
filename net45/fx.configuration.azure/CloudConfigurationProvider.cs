//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure;

namespace FX.Configuration.Azure
{
    public class CloudConfigurationProvider : BaseConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudConfigurationProvider"/> class.
        /// </summary>
        public CloudConfigurationProvider()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudConfigurationProvider"/> class.
        /// </summary>
        /// <param name="settingsDeserializers">The settings deserializers</param>
        public CloudConfigurationProvider(IEnumerable<object> settingsDeserializers)
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
            string stringValue = CloudConfigurationManager.GetSetting(valueKey);
            return stringValue;
        }
    }
}