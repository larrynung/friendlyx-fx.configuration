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
            Assert.Throws<InvalidOperationException>(() => new TestAppConfiguration((IEnumerable<IConfigurationProvider>)new[] { new TestAppConfigurationProviderWithEnvironment() }));
        }

        /// <summary>
        /// Reads the configuration correctly if the current environment is set
        /// </summary>
        [Fact]
        public void ReadsConfigurationCorrectlyIfCurrentIsSet()
        {
            // Arrange
            CurrentConfigurationEnvironment.Name = ConfigConstants.TestConfigEnvironment;
            TestAppConfiguration appConfiguration = new TestAppConfiguration((IEnumerable<IConfigurationProvider>)new[] { new TestAppConfigurationProviderWithEnvironment() });

            // Assert
            appConfiguration.StringProperty.ShouldBe("test-value");
        }

        /// <summary>
        /// Throws an exception if the current environment is set and no providers found
        /// </summary>
        [Fact]
        public void ThrowsIfCurrentIsSetAndNoProvider()
        {
            // Arrange
            CurrentConfigurationEnvironment.Name = ConfigConstants.TestConfigEnvironment;
            Assert.Throws<InvalidOperationException>(() => new TestAppConfiguration((IEnumerable<IConfigurationProvider>)new[] { new AppConfigurationProvider() }));
        }

        /// <summary>
        /// Reads the configuration in multiple environments correctly
        /// </summary>
        [Fact]
        public void ReadsConfigurationInMultipleEnvironmentsCorrectly()
        {
            // Arrange
            CurrentConfigurationEnvironment.Name = ConfigConstants.TestConfigEnvironment;
            TestAppConfiguration appConfiguration = new TestAppConfiguration((IEnumerable<IConfigurationProvider>)new[] { new TestAppConfigurationProviderWithEnvironment() });

            // Act & Assert
            appConfiguration.StringProperty.ShouldBe("test-value");

            CurrentConfigurationEnvironment.Name = ConfigConstants.TestConfigEnvironment2;
            appConfiguration = new TestAppConfiguration((IEnumerable<IConfigurationProvider>)new[] { new TestAppConfigurationProviderWithEnvironment() });
            appConfiguration.StringProperty.ShouldBe("test-value");

            CurrentConfigurationEnvironment.Name = "test3";
            Assert.Throws<InvalidOperationException>(() => new TestAppConfiguration((IEnumerable<IConfigurationProvider>)new[] { new TestAppConfigurationProviderWithEnvironment() }));
        }
    }
}