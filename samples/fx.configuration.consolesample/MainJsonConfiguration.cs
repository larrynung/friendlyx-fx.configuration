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

using System.Collections.Generic;
using FX.Configuration.Attributes;

namespace FX.Configuration.ConsoleSample
{
    /// <summary>
    /// A sample of a json configuration
    /// </summary>
    public class MainJsonConfiguration : JsonConfiguration
    {
        /// <summary>
        /// Gets the application version
        /// </summary>
        public string AppVersion { get; set; }

        /// <summary>
        /// Gets the complex details
        /// </summary>
        [JsonSetting]
        public ConfigurationComplexDetails ComplexDetails { get; set; }

        /// <summary>
        /// Gets the integer values
        /// </summary>
        [JsonSetting]
        public List<int> IntegerValues { get; set; }

        /// <summary>
        /// Gets the preprocessed setting
        /// </summary>
        [MyCustomSettingPreprocessor]
        public string PreprocessedSetting { get; set; }
    }
}