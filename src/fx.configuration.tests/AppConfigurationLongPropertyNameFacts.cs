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
    /// App configuration with short mapping unit tests
    /// </summary>
    public class AppConfigurationLongPropertyNameFacts
    {
        /// <summary>
        /// Application configuration provider fills configuration correctly
        /// </summary>
        [Fact]
        public void AppConfigProviderFillsConfigCorrectly()
        {
            // Arrange
            TestAppConfigurationLongPropertyName configuration = new TestAppConfigurationLongPropertyName();
            AppConfigurationProviderLongPropertyName configurationProvider = new AppConfigurationProviderLongPropertyName();

            // Act
            configurationProvider.Fill(configuration);

            // Assert
            VerifyConfiguration(configuration);
        }

        /// <summary>
        /// A simple application configuration fills correctly
        /// </summary>
        [Fact]
        public void SimpleAppConfigurationFillsCorrectly()
        {
            // Arrange
            TestAppConfigurationLongPropertyName configuration = new TestAppConfigurationLongPropertyName();

            // Assert
            VerifyConfiguration(configuration);
        }

        private static void VerifyConfiguration(TestAppConfigurationLongPropertyName configuration)
        {
            // Verify simple properties
            configuration.StringProperty.ShouldBe("test-value-long");
            configuration.BoolProperty.ShouldBe(true);
            configuration.DecimalProperty.ShouldBe((decimal)12.32);

            // Verify struct properties
            configuration.TimeSpanProperty.ShouldBe(TimeSpan.Parse("11:17:07.2787"));
            configuration.GuidProperty.ShouldBe(new Guid("63A0848A-586B-4108-867B-2980B0443401"));

            // Verify a first level complex property
            configuration.SomeComplexProperty.ShouldNotBeNull();
            configuration.SomeComplexProperty.Name.ShouldBe("long-complex-name");
            configuration.SomeComplexProperty.Id.ShouldBe(new Guid("296DE560-59E7-4EA1-A838-4700B1DACE50"));
            configuration.SomeComplexProperty.Price.ShouldBe((decimal)128.290);

            // Verify a second level complex property
            configuration.SomeComplexProperty.ComplexProperty.ShouldNotBeNull();
            configuration.SomeComplexProperty.ComplexProperty.Expiration.ShouldBe(TimeSpan.Parse("17.17:36:05"));
            configuration.SomeComplexProperty.ComplexProperty.Amount.ShouldBe(27.56);

            // Verify a third level complex property
            configuration.SomeComplexProperty.ComplexProperty.Value.ShouldNotBeNull();
            configuration.SomeComplexProperty.ComplexProperty.Value.Expiration.ShouldBe(TimeSpan.Parse("11:37:20.298"));
            configuration.SomeComplexProperty.ComplexProperty.Value.Amount.ShouldBe(21.23678);
            configuration.SomeComplexProperty.ComplexProperty.Value.Value.ShouldBeNull();

            // Verify enumerable properties
            configuration.StringList.ShouldNotBeNull();
            configuration.StringList.Count.ShouldBe(4);
            configuration.StringList[0].ShouldBe("item2-1");
            configuration.StringList[1].ShouldBe("item2-278");
            configuration.StringList[2].ShouldBe("item-267");
            configuration.StringList[3].ShouldBe("list2789");
        }
    }
}