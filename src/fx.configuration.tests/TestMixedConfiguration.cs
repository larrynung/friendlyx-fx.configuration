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

namespace FX.Configuration.Tests
{
    /// <summary>
    /// A mixed configuration (app.config + json) used in unit tests
    /// </summary>
    public class TestMixedConfiguration : MixedConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestMixedConfiguration"/> class.
        /// </summary>
        public TestMixedConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestMixedConfiguration"/> class.
        /// </summary>
        /// <param name="jsonConfigFilePath">The json configuration file path</param>
        public TestMixedConfiguration(string jsonConfigFilePath)
            : base(jsonConfigFilePath)
        {
        }

        /// <summary>
        /// Gets a string setting value setting from app.config
        /// </summary>
        public string MixedAppString { get; private set; }

        /// <summary>
        /// Gets a boolean setting value setting from app.config
        /// </summary>
        public bool MixedAppBoolean { get; private set; }

        /// <summary>
        /// Gets a decimal setting value setting from app.config
        /// </summary>
        public decimal MixedAppDecimal { get; private set; }

        /// <summary>
        /// Gets a guid setting value setting from app.config
        /// </summary>
        public Guid MixedAppGuid { get; private set; }

        /// <summary>
        /// Gets a complex setting value setting from app.config
        /// </summary>
        public ComplexMixedProperty MixedAppComplex { get; private set; }

        /// <summary>
        /// Gets or sets a string setting value from config.json
        /// </summary>
        public string MixedJsonString { get; set; }

        /// <summary>
        /// Gets or sets a boolean setting value from config.json
        /// </summary>
        public bool MixedJsonBoolean { get; set; }

        /// <summary>
        /// Gets or sets a decimal setting value from config.json
        /// </summary>
        public decimal MixedJsonDecimal { get; set; }

        /// <summary>
        /// Gets or sets a guid setting value from config.json
        /// </summary>
        public Guid MixedJsonGuid { get; set; }

        /// <summary>
        /// Gets or sets a complex setting value from config.json
        /// </summary>
        public ComplexMixedProperty MixedJsonComplex { get; set; }
    }

    /// <summary>
    /// A complex property type
    /// </summary>
    public class ComplexMixedProperty
    {
        /// <summary>
        /// Gets the identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the amount
        /// </summary>
        public decimal Amount { get; set; }
    }
}