//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using FX.Configuration.Tests.Environment;
using Xunit;
using Xunit.Should;

namespace FX.Configuration.Tests
{
    /// <summary>
    /// Current environment unit tests
    /// </summary>
    public class CurrentEnvironmentFacts
    {
        /// <summary>
        /// Reads the configuration correctly if the current environment is set
        /// </summary>
        [Fact]
        public void ReadsConfigurationCorrectlyIfCurrentIsNotSet()
        {
            // Arrange
            CurrentConfigurationEnvironment.Name = null;
            TestAppConfiguration appConfiguration = new TestAppConfiguration(new[] { new TestAppConfigurationProviderWithEnvironment() });

            // Assert
            appConfiguration.StringProperty.ShouldBeNull();
        }

        /// <summary>
        /// Reads the configuration correctly if the current environment is set
        /// </summary>
        [Fact]
        public void ReadsConfigurationCorrectlyIfCurrentIsSet()
        {
            // Arrange
            CurrentConfigurationEnvironment.Name = ConfigConstants.TestConfigEnvironment;
            TestAppConfiguration appConfiguration = new TestAppConfiguration(new[] { new TestAppConfigurationProviderWithEnvironment() });

            // Assert
            appConfiguration.StringProperty.ShouldBe("test-value");
        }

        /// <summary>
        /// Reads the configuration correctly if the current environment is set and no providers found
        /// </summary>
        [Fact]
        public void ReadsConfigurationCorrectlyIfCurrentIsSetAndNoProvider()
        {
            // Arrange
            CurrentConfigurationEnvironment.Name = ConfigConstants.TestConfigEnvironment;
            TestAppConfiguration appConfiguration = new TestAppConfiguration(new[] { new AppConfigurationProvider() });

            // Assert
            appConfiguration.StringProperty.ShouldBeNull();
        }

        /// <summary>
        /// Reads the configuration in multiple environments correctly
        /// </summary>
        [Fact]
        public void ReadsConfigurationInMultipleEnvironmentsCorrectly()
        {
            // Arrange
            CurrentConfigurationEnvironment.Name = ConfigConstants.TestConfigEnvironment;
            TestAppConfiguration appConfiguration = new TestAppConfiguration(new[] { new TestAppConfigurationProviderWithEnvironment() });

            // Act & Assert
            appConfiguration.StringProperty.ShouldBe("test-value");

            CurrentConfigurationEnvironment.Name = ConfigConstants.TestConfigEnvironment2;
            appConfiguration = new TestAppConfiguration(new[] { new TestAppConfigurationProviderWithEnvironment() });
            appConfiguration.StringProperty.ShouldBe("test-value");

            CurrentConfigurationEnvironment.Name = "test3";
            appConfiguration = new TestAppConfiguration(new[] { new TestAppConfigurationProviderWithEnvironment() });
            appConfiguration.StringProperty.ShouldBeNull();
        }
    }
}