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

using System.Reflection;
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
            : this(new ShortPropertyNameSettingNameResolver())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseConfigurationProvider" /> class.
        /// </summary>
        /// <param name="settingNameResolver">The setting name resolver</param>
        protected BaseConfigurationProvider(ISettingNameResolver settingNameResolver)
        {
            this.SettingNameResolver = settingNameResolver;
        }

        /// <summary>
        /// Gets the setting name resolver
        /// </summary>
        public ISettingNameResolver SettingNameResolver { get; private set; }

        /// <summary>
        /// Tries to get the raw value
        /// </summary>
        /// <param name="property">The property to get a value for</param>
        /// <param name="rawValue">The raw value</param>
        /// <returns>True if the value was found</returns>
        public virtual bool TryGetRawValue(PropertyInfo property, out object rawValue)
        {
            string settingName = this.SettingNameResolver.GetSettingName(property);
            return this.TryGetSettingValue(settingName, out rawValue);
        }

        /// <summary>
        /// Tries the get a value
        /// </summary>
        /// <param name="settingName">Name of the setting</param>
        /// <param name="rawValue">The raw value</param>
        /// <returns>True is the setting was found</returns>
        protected abstract bool TryGetSettingValue(string settingName, out object rawValue);
    }
}