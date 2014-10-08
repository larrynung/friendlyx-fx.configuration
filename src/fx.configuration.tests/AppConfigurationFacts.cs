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
using Xunit;
using Xunit.Should;

namespace FX.Configuration.Tests
{
    /// <summary>
    /// App configuration unit tests
    /// </summary>
    public class AppConfigurationFacts
    {
        /// <summary>
        /// Application configuration provider fills configuration correctly
        /// </summary>
        [Fact]
        public void AppConfigProviderFillsConfigCorrectly()
        {
            // Arrange
            TestAppConfiguration configuration = new TestAppConfiguration();
            AppConfigurationProvider configurationProvider = new AppConfigurationProvider();

            // Act
            configurationProvider.Fill(configuration);

            // Assert
            // Verify simple properties
            configuration.StringProperty.ShouldBe("test-value");
            configuration.BoolProperty.ShouldBe(true);
            configuration.DecimalProperty.ShouldBe((decimal)16.6271);

            // Verify struct properties
            configuration.TimeSpanProperty.ShouldBe(TimeSpan.Parse("19:18:09.19288"));
            configuration.GuidProperty.ShouldBe(new Guid("691BBBD5-DAC8-4991-8D58-A271D2388954"));
        }

        /// <summary>
        /// A simple application configuration fills correctly
        /// </summary>
        [Fact]
        public void SimpleAppConfigurationFillsCorrectly()
        {
            // Arrange
            TestAppConfiguration configuration = new TestAppConfiguration();

            // Assert
            // Verify simple properties
            configuration.StringProperty.ShouldBe("test-value");
            configuration.BoolProperty.ShouldBe(true);
            configuration.DecimalProperty.ShouldBe((decimal)16.6271);

            // Verify struct properties
            configuration.TimeSpanProperty.ShouldBe(TimeSpan.Parse("19:18:09.19288"));
            configuration.GuidProperty.ShouldBe(new Guid("691BBBD5-DAC8-4991-8D58-A271D2388954"));
        }

        /// <summary>
        /// Configuration fills from the application configuration provider correctly including custom culture set for some properties
        /// </summary>
        [Fact]
        public void AppConfigurationFillsCorrectlyWithCustomCultureSet()
        {
            // Arrange
            TestAppConfiguration configuration = new TestAppConfiguration(new[] { new CustomCultureAppConfigurationProvider()});

            // Assert
            // Verify simple properties
            configuration.StringProperty.ShouldBe("test-value");
            configuration.BoolProperty.ShouldBe(true);
            configuration.DecimalPropertyWithCustomCulture.ShouldBe((decimal)9.19288);
            configuration.DecimalPropertyInCustomCulture.ShouldBe((decimal)678.1826);
            configuration.DecimalWithCustomDeserializer.ShouldBe((decimal)1892.892);

            // Verify struct properties
            configuration.TimeSpanProperty.ShouldBe(TimeSpan.Parse("19:18:09.19288"));
            configuration.GuidProperty.ShouldBe(new Guid("691BBBD5-DAC8-4991-8D58-A271D2388954"));

            // Verify a first level complex property
            configuration.SomeComplexProperty.ShouldNotBeNull();
            configuration.SomeComplexProperty.Name.ShouldBe("short-complex-name");
            configuration.SomeComplexProperty.Id.ShouldBe(new Guid("296DE560-59E7-4EA1-A838-4700B1DACE50"));
            configuration.SomeComplexProperty.Price.ShouldBe((decimal)128.290);

            // Verify a second level complex property
            configuration.SomeComplexProperty.ComplexProperty.ShouldNotBeNull();
            configuration.SomeComplexProperty.ComplexProperty.Expiration.ShouldBe(TimeSpan.Parse("17.17:36:05"));
            configuration.SomeComplexProperty.ComplexProperty.Amount.ShouldBe(27.56);
            configuration.SomeComplexProperty.ComplexProperty.Value.ShouldNotBeNull();

            // Verify a third level complex property
            configuration.SomeComplexProperty.ComplexProperty.Value.Expiration.ShouldBe(TimeSpan.Parse("11:37:20.298"));
            configuration.SomeComplexProperty.ComplexProperty.Value.Amount.ShouldBe(21.23678);
            configuration.SomeComplexProperty.ComplexProperty.Value.Value.ShouldBeNull();

            // Verify a first level of another complex property
            configuration.AnotherComplexProperty.ShouldNotBeNull();
            configuration.AnotherComplexProperty.Name.ShouldBe("another-complex-name");
            configuration.AnotherComplexProperty.Id.ShouldBe(new Guid("A7997FA0-BBA9-413D-BF74-8ED8B1942771"));
            configuration.AnotherComplexProperty.Price.ShouldBe((decimal)7.23);

            // Verify a second level of another complex property
            configuration.AnotherComplexProperty.ComplexProperty.ShouldNotBeNull();
            configuration.AnotherComplexProperty.ComplexProperty.Expiration.ShouldBe(TimeSpan.Parse("18.21:17:06"));
            configuration.AnotherComplexProperty.ComplexProperty.Amount.ShouldBe(107.51);

            // Verify a third level of another complex property
            configuration.AnotherComplexProperty.ComplexProperty.Value.ShouldNotBeNull();
            configuration.AnotherComplexProperty.ComplexProperty.Value.Expiration.ShouldBe(TimeSpan.Parse("11:07:23.3261"));
            configuration.AnotherComplexProperty.ComplexProperty.Value.Amount.ShouldBe(819.267);
            configuration.AnotherComplexProperty.ComplexProperty.Value.Value.ShouldBeNull();
        }
    }
}