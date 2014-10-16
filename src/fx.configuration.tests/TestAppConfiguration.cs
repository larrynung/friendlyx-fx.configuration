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
using FX.Configuration.Attributes;
using FX.Configuration.Deserializers;

namespace FX.Configuration.Tests
{
    /// <summary>
    /// A configuration used in unit tests
    /// </summary>
    internal class TestAppConfiguration : AppConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestAppConfiguration"/> class.
        /// </summary>
        public TestAppConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestAppConfiguration"/> class.
        /// </summary>
        /// <param name="configurationProviders">The configuration providers</param>
        public TestAppConfiguration(IEnumerable<IConfigurationProvider> configurationProviders)
            : base(configurationProviders)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestAppConfiguration" /> class.
        /// </summary>
        /// <param name="deserializers">The deserializers</param>
        public TestAppConfiguration(IEnumerable<object> deserializers)
            : base(deserializers)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestAppConfiguration" /> class.
        /// </summary>
        /// <param name="configurationProviders">The configuration providers</param>
        /// <param name="deserializers">The deserializers</param>
        public TestAppConfiguration(IEnumerable<IConfigurationProvider> configurationProviders, IEnumerable<object> deserializers)
            : base(configurationProviders, deserializers)
        {
        }

        /// <summary>
        /// Gets the test property value
        /// </summary>
        public string StringProperty { get; private set; }

        /// <summary>
        /// Gets a boolean property
        /// </summary>
        public bool BoolProperty { get; private set; }

        /// <summary>
        /// Gets the unique identifier property
        /// </summary>
        public Guid GuidProperty { get; private set; }

        /// <summary>
        /// Gets the time span property
        /// </summary>
        public TimeSpan TimeSpanProperty { get; private set; }

        /// <summary>
        /// Gets the simple decimal property
        /// </summary>
        public decimal DecimalProperty { get; private set; }

        /// <summary>
        /// Gets the decimal property with custom culture
        /// </summary>
        [CustomCulture("ru-RU")]
        public decimal DecimalPropertyWithCustomCulture { get; private set; }

        /// <summary>
        /// Gets the decimal with custom deserializer specified
        /// </summary>
        [Deserializer(typeof(CustomCultureDecimalDeserializer))]
        public decimal DecimalWithCustomDeserializer { get; private set; }

        /// <summary>
        /// Gets some complex value
        /// </summary>
        [Deserializer(typeof(JsonDeserializer))]
        public ComplexSettingValue SomeComplexProperty { get; private set; }

        /// <summary>
        /// Gets another complex property
        /// </summary>
        [JsonSetting]
        public ComplexSettingValue AnotherComplexProperty { get; private set; }
    }
}