//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Collections.Generic;

namespace FX.Configuration
{
    /// <summary>
    /// The default configuration reading settings from app.config resolving setting keys based on short property names
    /// </summary>
    public abstract class AppConfigurationShortMapping : BaseConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfiguration" /> class.
        /// </summary>
        protected AppConfigurationShortMapping()
            : this(new[] { new AppConfigurationProviderLongPropertyName() })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfiguration" /> class.
        /// </summary>
        /// <param name="configurationProviders">The configuration providers.</param>
        protected AppConfigurationShortMapping(IEnumerable<IConfigurationProvider> configurationProviders)
            : base(configurationProviders)
        {
            base.Fill();
        }
    }
}