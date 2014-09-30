//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace FX.Configuration
{
    /// <summary>
    /// A base configuration class
    /// </summary>
    public abstract class BaseConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BaseConfiguration" /> class.
        /// </summary>
        protected BaseConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:BaseConfiguration" /> class.
        /// </summary>
        /// <param name="configurationProviders">The configuration providers.</param>
        protected BaseConfiguration(IEnumerable<IConfigurationProvider> configurationProviders)
        {
            this.ConfigurationProviders = configurationProviders.ToList();
        }

        /// <summary>
        /// Gets the configuration providers
        /// </summary>
        protected List<IConfigurationProvider> ConfigurationProviders { get; private set; }

        /// <summary>
        /// Fills this instance of configuration
        /// </summary>
        protected virtual void Fill()
        {
            IEnumerable<IConfigurationProvider> providers;
            if (string.IsNullOrEmpty(CurrentConfigurationEnvironment.Name))
            {
                // If current environment name is not set then we find providers with no EnvironmentAttribute or EnvironmentAttribute.Name is empty
                providers = this.ConfigurationProviders.Where(provider => !provider.GetConfigurationEnvironemntAttributes().Any() || provider.GetConfigurationEnvironemntAttributes().Any(attribute => string.IsNullOrEmpty(attribute.Name)));
            }
            else
            {
                // Otherwise we find a match
                providers = this.ConfigurationProviders.Where(provider => provider.GetConfigurationEnvironemntAttributes().Any(attribute => attribute.Name == CurrentConfigurationEnvironment.Name));
            }

            foreach (IConfigurationProvider configurationProvider in providers)
            {
                configurationProvider.Fill(this);
            }
        }
    }
}