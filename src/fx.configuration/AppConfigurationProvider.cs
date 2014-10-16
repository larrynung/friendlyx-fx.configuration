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

using System.Configuration;
using System.Linq;
using FX.Configuration.Resolvers;

namespace FX.Configuration
{
    /// <summary>
    /// A configuration provider reading settings from an app configuration file
    /// </summary>
    public class AppConfigurationProvider : BaseConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationProvider"/> class.
        /// </summary>
        public AppConfigurationProvider()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationProvider" /> class.
        /// </summary>
        /// <param name="settingNameResolver">The setting name resolver.</param>
        public AppConfigurationProvider(ISettingNameResolver settingNameResolver)
            : base(settingNameResolver)
        {
        }

        /// <summary>
        /// Tries the get a value
        /// </summary>
        /// <param name="settingName">Name of the setting</param>
        /// <param name="rawValue">The raw value</param>
        /// <returns>True is the setting was found</returns>
        protected override bool TryGetSettingValue(string settingName, out object rawValue)
        {
            bool found = ConfigurationManager.AppSettings.AllKeys.Any(key => key == settingName);

            rawValue = found ? ConfigurationManager.AppSettings[settingName] : null;

            return found;
        }
    }
}