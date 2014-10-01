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
using System.Configuration;

namespace FX.Configuration
{
    /// <summary>
    /// A configuration provider reading settings from an app configuration file resolving setting keys based on short property names
    /// </summary>
    public class AppConfigurationProviderLongPropertyName : BaseConfigurationProviderLongPropertyName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationProvider"/> class.
        /// </summary>
        public AppConfigurationProviderLongPropertyName()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationProvider"/> class.
        /// </summary>
        /// <param name="settingsDeserializers">The settings deserializers</param>
        public AppConfigurationProviderLongPropertyName(IEnumerable<object> settingsDeserializers)
            : base(settingsDeserializers)
        {
        }

        /// <summary>
        /// Gets the value
        /// </summary>
        /// <param name="valueKey">The value key</param>
        /// <returns>The value</returns>
        public override object GetRawValue(string valueKey)
        {
            string stringValue = ConfigurationManager.AppSettings[valueKey];
            return stringValue;
        }
    }
}
