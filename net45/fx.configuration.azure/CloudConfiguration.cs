//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System.Collections.Generic;

namespace FX.Configuration.Azure
{
    /// <summary>
    /// The default configuration reading settings from Azure cloud configuration manager
    /// </summary>
    public abstract class CloudConfiguration : BaseConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudConfiguration"/> class.
        /// </summary>
        protected CloudConfiguration()
            : base(new[] { new CloudConfigurationProvider() })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudConfiguration"/> class.
        /// </summary>
        /// <param name="configurationProviders">The configuration providers.</param>
        protected CloudConfiguration(IEnumerable<IConfigurationProvider> configurationProviders)
            : base(configurationProviders)
        {
        }
    }
}