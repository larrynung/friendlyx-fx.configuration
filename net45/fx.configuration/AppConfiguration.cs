//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System.Collections.Generic;

namespace FX.Configuration
{
    /// <summary>
    /// The default configuration reading settings from app.config
    /// </summary>
    public abstract class AppConfiguration : BaseConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfiguration" /> class.
        /// </summary>
        protected AppConfiguration()
            : this(new[] { new AppConfigurationProvider() })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfiguration" /> class.
        /// </summary>
        /// <param name="configurationProviders">The configuration providers.</param>
        protected AppConfiguration(IEnumerable<IConfigurationProvider> configurationProviders)
            : base(configurationProviders)
        {
            base.Fill();
        }
    }
}