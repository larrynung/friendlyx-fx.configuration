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
using System.Reflection;

namespace FX.Configuration.Tests
{
    /// <summary>
    /// A custom configuration provider
    /// </summary>
    internal class CustomCultureAppConfigurationProvider : AppConfigurationProvider
    {
        /// <summary>
        /// Gets the deserialized value
        /// </summary>
        /// <param name="deserializers">The deserializers</param>
        /// <param name="property">The property</param>
        /// <param name="rawSetting">The raw setting</param>
        /// <returns>The value</returns>
        protected override object GetDeserializedValue(IEnumerable<object> deserializers, PropertyInfo property, object rawSetting)
        {
            object result;
            if (property.Name == "DecimalPropertyInCustomCulture")
            {
                result = Convert.ToDecimal(rawSetting, new CultureInfo("ru-RU"));
            }
            else
            {
                result = base.GetDeserializedValue(deserializers, property, rawSetting);
            }

            return result;
        }
    }
}