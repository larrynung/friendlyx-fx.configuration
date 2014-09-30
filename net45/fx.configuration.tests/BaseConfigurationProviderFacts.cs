//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
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