/* The MIT License (MIT)
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
using System.Globalization;
using System.Linq;
using System.Reflection;
using FX.Configuration.Deserializers;

namespace FX.Configuration
{
    /// <summary>
    /// A configuration pipeline
    /// </summary>
    public class ConfigurationPipeline : IConfigurationPipeline
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationPipeline"/> class.
        /// </summary>
        /// <param name="configurationProviders">The configuration providers</param>
        public ConfigurationPipeline(IEnumerable<IConfigurationProvider> configurationProviders)
            : this(configurationProviders, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationPipeline" /> class.
        /// </summary>
        /// <param name="configurationProviders">The configuration providers</param>
        /// <param name="ignoreMissingValues">if set to <c>true</c> then ignore missing values, otherwise throw an exception</param>
        public ConfigurationPipeline(IEnumerable<IConfigurationProvider> configurationProviders, bool ignoreMissingValues)
            : this(configurationProviders, ignoreMissingValues, new[] { new DefaultDeserializer() })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationPipeline" /> class.
        /// </summary>
        /// <param name="configurationProviders">The configuration providers</param>
        /// <param name="deserializers">The deserializers used if no deserializer specified for a property</param>
        public ConfigurationPipeline(IEnumerable<IConfigurationProvider> configurationProviders, IEnumerable<object> deserializers)
            : this(configurationProviders, true, deserializers)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationPipeline" /> class.
        /// </summary>
        /// <param name="configurationProviders">The configuration providers</param>
        /// <param name="ignoreMissingValues">if set to <c>true</c> then ignore missing values, otherwise throw an exception</param>
        /// <param name="deserializers">The deserializers used if no deserializer specified for a property</param>
        public ConfigurationPipeline(IEnumerable<IConfigurationProvider> configurationProviders, bool ignoreMissingValues, IEnumerable<object> deserializers)
        {
            this.ConfigurationProviders = configurationProviders;
            this.IgnoreMissingValues = ignoreMissingValues;
            this.Deserializers = deserializers.ToList();
        }

        /// <summary>
        /// Gets the configuration providers
        /// </summary>
        public IEnumerable<IConfigurationProvider> ConfigurationProviders { get; private set; }

        /// <summary>
        /// Gets a value indicating whether ignore missing values or not
        /// </summary>
        public bool IgnoreMissingValues { get; private set; }

        /// <summary>
        /// Gets the fallback deserializers
        /// </summary>
        public List<object> Deserializers { get; private set; }

        /// <summary>
        /// Runs a configuration pipeline to fill out the specified configuration
        /// </summary>
        /// <typeparam name="T">The type of configuration</typeparam>
        /// <param name="config">The configuration to fill out</param>
        public void Run<T>(T config) where T : BaseConfiguration
        {
            List<IConfigurationProvider> providers = this.GetProvidersForCurrentEnvironment().ToList();

            if (providers.Count == 0)
            {
                throw new InvalidOperationException(string.Format("No providers found for configuration. Check pipeline initialization"));
            }

            this.RunForConfiguration(config, providers);
        }

        private IEnumerable<IConfigurationProvider> GetProvidersForCurrentEnvironment()
        {
            IEnumerable<IConfigurationProvider> providers;
            if (string.IsNullOrEmpty(CurrentConfigurationEnvironment.Name))
            {
                // If current environment name is not set then we find providers with no EnvironmentAttribute or EnvironmentAttribute.Name is empty
                providers = this.ConfigurationProviders.Where(provider => !provider.GetConfigurationEnvironmentAttributes().Any() || provider.GetConfigurationEnvironmentAttributes().Any(attribute => string.IsNullOrEmpty(attribute.Name)));
            }
            else
            {
                // Otherwise we find a match
                providers = this.ConfigurationProviders.Where(provider => provider.GetConfigurationEnvironmentAttributes().Any(attribute => attribute.Name == CurrentConfigurationEnvironment.Name));
            }
            return providers;
        }

        private void RunForConfiguration<T>(T config, List<IConfigurationProvider> providers)
        {
            if (providers.Count > 0)
            {
                Type configurationType = config.GetType();
                PropertyInfo[] properties = configurationType.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    // Get a raw value from a provider
                    object rawSetting = this.GetRawPropertyValue(property, providers);

                    // TODO: Add the raw value preprocessing (like for decription)

                    // Get deserializers can be used for the property (it can be a deserializer defined in a property attribute or in the pipeline itself)
                    List<object> deserializers = this.GetDeserializers(property);

                    // Deserialize the raw value
                    object value = this.GetDeserializedValue(deserializers, property, rawSetting);

                    property.SetValue(config, value, new object[] { });
                }
            }
        }

        /// <summary>
        /// Gets the list of deserializers for the given property
        /// </summary>
        /// <param name="property">The property</param>
        /// <returns>A list of deserializers</returns>
        protected  virtual List<object> GetDeserializers(PropertyInfo property)
        {
            List<object> deserializers = new List<object>();

            object deserializer = property.GetDeserializerFromAttribute();
            if (deserializer != null)
            {
                // We use whatever defined in the property
                deserializers.Add(deserializer);
            }
            else if (this.Deserializers.Count > 0)
            {
                // Otherwise we use what was passed in the constructor
                deserializers.AddRange(this.Deserializers);
            }

            return deserializers;
        }

        /// <summary>
        /// Gets the raw property value
        /// </summary>
        /// <param name="property">The property</param>
        /// <param name="configurationProviders">The list of configuration providers</param>
        /// <returns>The raw value</returns>
        /// <exception cref="System.InvalidOperationException">Couldn't find a value for the property</exception>
        protected virtual object GetRawPropertyValue(PropertyInfo property, IEnumerable<IConfigurationProvider> configurationProviders)
        {
            object rawValue = null;
            bool found = configurationProviders.Any(provider => provider.TryGetRawValue(property, out rawValue));

            if (!found && !this.IgnoreMissingValues)
            {
                throw new InvalidOperationException(string.Format("Couldn't find a value for the property '{0}'", property.Name));
            }

            return rawValue;
        }

        /// <summary>
        /// Gets the deserialized value
        /// </summary>
        /// <param name="deserializers">The deserializers</param>
        /// <param name="property">The property</param>
        /// <param name="rawSetting">The raw setting</param>
        /// <returns>The deserialized value</returns>
        protected virtual object GetDeserializedValue(IEnumerable<object> deserializers, PropertyInfo property, object rawSetting)
        {
            CultureInfo customCultureInfo = property.GetCustomCultureInfo();

            object deserializedValue = null;
            bool hasBeenDeserialized = false;

            foreach (object deserializer in deserializers)
            {
                Type foundInterface = deserializer.GetInterfaceType(property.PropertyType);

                if (foundInterface == null)
                {
                    continue;
                }

                object value = deserializer.GetValueFromInterface(rawSetting, property, customCultureInfo, foundInterface);
                deserializedValue = value;
                hasBeenDeserialized = true;
                break;
            }
            
            if (!hasBeenDeserialized)
            {
                throw new InvalidOperationException(string.Format("Couldn't desrialize a property value. Property name: '{0}'. Raw value: '{1}'", property.Name, rawSetting));
            }

            return deserializedValue;
        }
    }
}