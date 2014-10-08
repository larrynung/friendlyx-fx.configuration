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
using FX.Configuration.Resolvers;

namespace FX.Configuration
{
    /// <summary>
    /// A base configuration provider
    /// </summary>
    public abstract class BaseConfigurationProvider : IConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConfigurationProvider"/> class.
        /// </summary>
        protected BaseConfigurationProvider()
            : this(new object[] { new DefaultDeserializer() })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConfigurationProvider"/> class.
        /// </summary>
        /// <param name="settingsDeserializers">The settings deserializers</param>
        protected BaseConfigurationProvider(IEnumerable<object> settingsDeserializers)
            : this(settingsDeserializers, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConfigurationProvider" /> class.
        /// </summary>
        /// <param name="settingNameResolver">The setting name resolver</param>
        protected BaseConfigurationProvider(ISettingNameResolver settingNameResolver)
            : this(new object[] { new DefaultDeserializer() }, true, settingNameResolver)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConfigurationProvider" /> class.
        /// </summary>
        /// <param name="settingNameResolver">The setting name resolver</param>
        /// <param name="settingsDeserializers">The settings deserializers</param>
        protected BaseConfigurationProvider(IEnumerable<object> settingsDeserializers, ISettingNameResolver settingNameResolver)
            : this(settingsDeserializers, true, settingNameResolver)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConfigurationProvider"/> class.
        /// </summary>
        /// <param name="settingsDeserializers">The settings deserializers.</param>
        /// <param name="ignoreEmptyValues">if set to <c>true</c> then ignore empty values</param>
        protected BaseConfigurationProvider(IEnumerable<object> settingsDeserializers, bool ignoreEmptyValues)
            : this(settingsDeserializers, ignoreEmptyValues, new ShortPropertyNameSettingNameResolver())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConfigurationProvider" /> class.
        /// </summary>
        /// <param name="settingNameResolver">The setting name resolver</param>
        /// <param name="settingsDeserializers">The settings deserializers</param>
        /// <param name="ignoreEmptyValues">if set to <c>true</c> [ignore empty values].</param>
        protected BaseConfigurationProvider(IEnumerable<object> settingsDeserializers, bool ignoreEmptyValues, ISettingNameResolver settingNameResolver)
        {
            this.SettingsDeserializers = settingsDeserializers.ToList();
            this.SettingNameResolver = settingNameResolver;
            this.IgnoreEmptyValues = ignoreEmptyValues;
        }

        /// <summary>
        /// Gets the settings deserializers
        /// </summary>
        public IEnumerable<object> SettingsDeserializers
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the setting name resolver
        /// </summary>
        public ISettingNameResolver SettingNameResolver { get; set; }

        /// <summary>
        /// Gets a value indicating whether ignore empty values or not
        /// </summary>
        public bool IgnoreEmptyValues { get; private set; }

        /// <summary>
        /// Gets the properties of the given type
        /// </summary>
        /// <param name="configurationType">Type of the configuration.</param>
        /// <returns>An array of property infos</returns>
        protected virtual PropertyInfo[] GetProperties(Type configurationType)
        {
            return configurationType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// Gets the value
        /// </summary>
        /// <param name="valueKey">The value key</param>
        /// <returns>The value</returns>
        public abstract object GetRawValue(string valueKey);

        /// <summary>
        /// Fills the configuration
        /// </summary>
        /// <typeparam name="T">The type of the configuration</typeparam>
        public void Fill<T>(T config) where T : BaseConfiguration
        {
            Type configurationType = config.GetType();
            PropertyInfo[] properties = this.GetProperties(configurationType);

            foreach (PropertyInfo property in properties)
            {
                string settingName = this.SettingNameResolver.GetSettingName(property);
                object rawSetting = this.GetRawValue(settingName);

                object deserializer = property.GetDeserializerFromAttribute();

                object value;
                if (deserializer == null)
                {
                    value = this.GetDeserializedValue(this.SettingsDeserializers, property, rawSetting);
                }
                else
                {
                    // Here we use the deserializer defined in the attribute
                    value = this.GetDeserializedValueByAttribute(deserializer, property, rawSetting);
                }

                property.SetValue(config, value, new object[] { });
            }
        }

        /// <summary>
        /// Gets the deserialized value by attribute
        /// </summary>
        /// <param name="deserializer">The deserializer</param>
        /// <param name="property">The property</param>
        /// <param name="rawSetting">The raw setting</param>
        /// <returns>The value</returns>
        protected virtual object GetDeserializedValueByAttribute(object deserializer, PropertyInfo property, object rawSetting)
        {
            CultureInfo customCultureInfo = property.GetCustomCultureInfo();

            Type foundInterface = deserializer.GetInterfaceType(property.PropertyType);
            if (foundInterface == null && !property.PropertyType.IsValueType)
            {
                // We couldn't find a specific interface so for ref type will try to find an interface supports 'object'
                foundInterface = deserializer.GetInterfaceType(typeof(object));
            }

            if (foundInterface == null)
            {
                throw new InvalidOperationException(string.Format("Invalid deserializer type specified in property: {0}.", property.Name));
            }

            object value = deserializer.GetValueFromInterface(rawSetting, property.PropertyType, customCultureInfo, foundInterface);
            return value;
        }

        /// <summary>
        /// Gets the deserialized value
        /// </summary>
        /// <param name="deserializers">The deserializers</param>
        /// <param name="property">The property</param>
        /// <param name="rawSetting">The raw setting</param>
        /// <returns>The value</returns>
        protected virtual object GetDeserializedValue(IEnumerable<object> deserializers, PropertyInfo property, object rawSetting)
        {
            CultureInfo customCultureInfo = property.GetCustomCultureInfo();

            foreach (object deserializer in deserializers)
            {
                Type foundInterface = deserializer.GetInterfaceType(property.PropertyType);

                if (foundInterface == null)
                {
                    continue;
                }

                object value = deserializer.GetValueFromInterface(rawSetting, property.PropertyType, customCultureInfo, foundInterface);
                return value;
            }

            if (!this.IgnoreEmptyValues)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Could not deserialize a setting for a property '{0}' from a raw value '{1}'", property, rawSetting));
            }

            return null;
        }
    }
}