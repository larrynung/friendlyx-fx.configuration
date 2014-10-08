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

namespace FX.Configuration.Deserializers
{
    /// <summary>
    /// Enumerable setting deserializer
    /// </summary>
    public class EnumerableSettingDeserializer<T> : ISettingDeserializer<IEnumerable<T>>, ISettingDeserializer<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableSettingDeserializer{T}"/> class.
        /// </summary>
        /// <param name="delimiter">The delimiter</param>
        public EnumerableSettingDeserializer(string delimiter)
        {
            if (string.IsNullOrEmpty(delimiter))
            {
                throw new ArgumentNullException("delimiter");
            }

            this.Delimiter = delimiter;
        }

        /// <summary>
        /// Gets the delimiter between items
        /// </summary>
        public string Delimiter { get; private set; }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out IEnumerable<T> result)
        {
            string inputString = input as string;
            if (inputString == null)
            {
                throw new InvalidOperationException(string.Format("Cannot deserialize Enumerable setting. The input type is not castable to string."));
            }

            string[] values = inputString.Split(this.Delimiter.ToCharArray());

            Type typeOfItem = typeof(T);
            result = (from stringValue in values
                      let deserializer = new DefaultDeserializer()
                      let foundInterface = deserializer.GetInterfaceType(typeOfItem)
                      select deserializer.GetValueFromInterface(stringValue, typeOfItem, cultureInfo, foundInterface)).ToList().ConvertAll(item => (T)item);
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out object result)
        {
            IEnumerable<T> enumerableResult;
            this.Deserialize(input, outputType, cultureInfo, out enumerableResult);
            result = enumerableResult;
        }
    }
}