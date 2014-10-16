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

using System.Globalization;
using System.Reflection;
using Newtonsoft.Json;

namespace FX.Configuration.Deserializers
{
    /// <summary>
    /// JSON deserializer
    /// </summary>
    public class JsonDeserializer : ISettingDeserializer<object>
    {
        /// <summary>
        /// Gets the serializer settings
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <returns>The JSON serializer settings</returns>
        protected virtual JsonSerializerSettings GetSerializerSettings(object input, CultureInfo cultureInfo)
        {
            JsonSerializerSettings settings;

            if (cultureInfo != null)
            {
                settings = new JsonSerializerSettings
                {
                    Culture = cultureInfo,
                };
            }
            else
            {
                settings = null;
            }

            return settings;
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="property">The property</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, PropertyInfo property, CultureInfo cultureInfo, out object result)
        {
            if ((input as string) == null)
            {
                result = null;
            }
            else
            {
                JsonSerializerSettings settings = this.GetSerializerSettings(input, cultureInfo);
                result = JsonConvert.DeserializeObject((string)input, property.PropertyType, settings);
            }
        }
    }
}