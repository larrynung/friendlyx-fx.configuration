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
using FX.Configuration.Attributes;
using FX.Configuration.Deserializers;

namespace FX.Configuration.Tests
{
    /// <summary>
    /// A configuration with short mapping used in unit tests
    /// </summary>
    public class TestAppConfigurationShortMapping : AppConfigurationShortMapping
    {
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

        [Deserializer(typeof(JsonDeserializer))]
        public ComplexSettingValue SomeComplexProperty { get; private set; }
    }
}