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

namespace FX.Configuration.Deserializers
{
    /// <summary>
    /// The default deserializer
    /// </summary>
    public class DefaultDeserializer :
        ISettingDeserializer<string>,
        ISettingDeserializer<bool>,
        ISettingDeserializer<char>,
        ISettingDeserializer<sbyte>,
        ISettingDeserializer<byte>,
        ISettingDeserializer<short>,
        ISettingDeserializer<ushort>,
        ISettingDeserializer<int>,
        ISettingDeserializer<uint>,
        ISettingDeserializer<long>,
        ISettingDeserializer<ulong>,
        ISettingDeserializer<float>,
        ISettingDeserializer<double>,
        ISettingDeserializer<decimal>,
        ISettingDeserializer<DateTime>,
        ISettingDeserializer<TimeSpan>,
        ISettingDeserializer<Guid>,
        ISettingDeserializer<Uri>
    {

        /// <summary>
        /// Gets the default value
        /// </summary>
        /// <param name="outputType">Type of the output value</param>
        /// <returns>A default value</returns>
        protected static object GetDefaultValue(Type outputType)
        {
            object deserializedValue = outputType.IsValueType ? Activator.CreateInstance(outputType) : null;
            return deserializedValue;
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out string result)
        {
            result = input == null ? null : input.ToString();
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out bool result)
        {
            result = Convert.ToBoolean(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out char result)
        {
            result = Convert.ToChar(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        /// <returns>The deserialized value</returns>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out sbyte result)
        {
            result = Convert.ToSByte(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out byte result)
        {
            result = Convert.ToByte(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out short result)
        {
            result = Convert.ToInt16(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out ushort result)
        {
            result = Convert.ToUInt16(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out int result)
        {
            result = Convert.ToInt32(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out uint result)
        {
            result = Convert.ToUInt32(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out long result)
        {
            result = Convert.ToInt64(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out ulong result)
        {
            result = Convert.ToUInt64(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out float result)
        {
            result = Convert.ToSingle(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out double result)
        {
            result = Convert.ToDouble(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out decimal result)
        {
            result = Convert.ToDecimal(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out DateTime result)
        {
            result = Convert.ToDateTime(input, cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out TimeSpan result)
        {
            result = ((string)input).Parse(cultureInfo);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out Guid result)
        {
            result = new Guid((string)input);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out Uri result)
        {
            result = new Uri((string)input);
        }
    }
}