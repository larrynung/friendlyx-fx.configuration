//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using FX.Configuration.Resolvers;

namespace FX.Configuration
{
    /// <summary>
    /// The configuration provider resolving setting keys based on long property names
    /// </summary>
    public abstract class BaseConfigurationProviderLongPropertyName : BaseConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConfigurationProviderLongPropertyName"/> class.
        /// </summary>
        protected BaseConfigurationProviderLongPropertyName()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConfigurationProviderLongPropertyName"/> class.
        /// </summary>
        /// <param name="settingsDeserializers">The settings deserializers</param>
        protected BaseConfigurationProviderLongPropertyName(IEnumerable<object> settingsDeserializers)
            : base(settingsDeserializers, new LongPropertyNameSettingNameResolver())
        {
        }
    }
}