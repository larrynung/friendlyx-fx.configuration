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
using System.Globalization;
using System.Reflection;
using FX.Configuration.Deserializers;

namespace FX.Configuration.Tests
{
    /// <summary>
    /// A custom configuration provider
    /// </summary>
    internal class CustomCultureDeserializer : ISettingDeserializer<decimal>
    {
        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="property">The property</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, PropertyInfo property, CultureInfo cultureInfo, out decimal result)
        {
            if (property.Name == "DecimalPropertyInCustomCulture")
            {
                result = Convert.ToDecimal(input, new CultureInfo("ru-RU"));
            }
            else
            {
                result = 0;
            }
        }
    }
}