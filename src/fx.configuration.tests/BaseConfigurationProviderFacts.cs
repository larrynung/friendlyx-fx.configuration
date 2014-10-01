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
using Xunit;
using Xunit.Should;

namespace FX.Configuration.Tests
{
    /// <summary>
    /// Unit tests for the BaseConfigurationProvider
    /// </summary>
    public class BaseConfigurationProviderFacts
    {
        /// <summary>
        /// A custom application configuration
        /// </summary>
        private class CustomAppConfiguration : AppConfiguration
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CustomAppConfiguration"/> class.
            /// </summary>
            /// <param name="configurationProviders">The configuration providers.</param>
            public CustomAppConfiguration(IEnumerable<IConfigurationProvider> configurationProviders)
                : base(configurationProviders)
            {
            }

            /// <summary>
            /// Gets or sets the test property value
            /// </summary>
            public string StringProperty { get; private set; }

            /// <summary>
            /// Gets or sets a boolean property
            /// </summary>
            public bool BoolProperty { get; private set; }

            /// <summary>
            /// Gets or sets the simple decimal property
            /// </summary>
            public decimal DecimalProperty { get; private set; }
        }

        /// <summary>
        /// Unit tests for the GetSettingName method
        /// </summary>
        public class GetSettingNameMethod : BaseConfigurationProviderFacts
        {
            /// <summary>
            /// Overrides the setting keys correctly
            /// </summary>
            [Fact]
            public void OverridesSettingKeysCorrectly()
            {
                // Arrange
                CustomAppConfiguration configuration = new CustomAppConfiguration(new[] { new AppConfigurationProvider(new CustomSettingNameResolver()) });

                // Assert
                configuration.StringProperty.ShouldBe("custom-test-value");
                configuration.BoolProperty.ShouldBe(true);
                configuration.DecimalProperty.ShouldBe((decimal)6728.216);
            }
        }
    }
}