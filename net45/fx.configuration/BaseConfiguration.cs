﻿/* The MIT License (MIT)
*
* Copyright (c) 2014 FriendlyX
* Permission is hereby granted, free of charge, to any person obtaining a copy of
* this software and associated documentation files (the "Software"), to deal in
* the Software without restriction, including without limitation the rights to
* use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
* the Software, and to permit persons to whom the Software is furnished to do so,
* subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
* FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
* COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
* IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
* CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

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