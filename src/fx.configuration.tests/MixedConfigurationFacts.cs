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
    /// Unit tests for the MixedConfiguration class
    /// </summary>
    public class MixedConfigurationFacts
    {
        /// <summary>
        /// Verifies that the configuration has been filled out correctly from app.config and config.json
        /// </summary>
        [Fact]
        public void FillsAllPropetiesFromAppAndJsonConfigsCorrectly()
        {
            // Arrange
            TestMixedConfiguration configuration = new TestMixedConfiguration();

            // Assert

            // Check all properties filled out from app.config
            configuration.MixedAppString.ShouldBe("mixed-app-string-value");
            configuration.MixedAppBoolean.ShouldBeTrue();
            configuration.MixedAppDecimal.ShouldBe((decimal)7829.2781);
            configuration.MixedAppGuid.ShouldBe(new Guid("0C76271C-BF3E-497E-96E5-840E2EC2FCCB"));
            configuration.MixedAppComplex.ShouldNotBeNull();
            configuration.MixedAppComplex.Id.ShouldBe(new Guid("EDB4B244-85DF-4135-9DE2-126CC30C8B2B"));
            configuration.MixedAppComplex.Name.ShouldBe("mixed-app-name");
            configuration.MixedAppComplex.Amount.ShouldBe((decimal)165.289);

            // Check all properties filled out from config.json
            configuration.MixedJsonString.ShouldBe("mixed-json-string-value");
            configuration.MixedJsonBoolean.ShouldBeFalse();
            configuration.MixedJsonDecimal.ShouldBe((decimal)21768.2893);
            configuration.MixedJsonGuid.ShouldBe(new Guid("5F86032B-6F9A-4114-93D3-40AED21972E1"));
            configuration.MixedJsonComplex.ShouldNotBeNull();
            configuration.MixedJsonComplex.Id.ShouldBe(new Guid("9B0B59CF-758C-42E3-9BD0-BB1E8853A750"));
            configuration.MixedJsonComplex.Name.ShouldBe("mixed-json-name");
            configuration.MixedJsonComplex.Amount.ShouldBe((decimal)2678.18792);
        }

        /// <summary>
        /// Verifies that the configuration has been filled out correctly from app.config and customConfig.json
        /// </summary>
        [Fact]
        public void FillsAllPropetiesFromAppAndCustomJsonConfigsCorrectly()
        {
            // Arrange
            TestMixedConfiguration configuration = new TestMixedConfiguration("customConfig.json");

            // Assert

            // Check all properties filled out from app.config
            configuration.MixedAppString.ShouldBe("mixed-app-string-value");
            configuration.MixedAppBoolean.ShouldBeTrue();
            configuration.MixedAppDecimal.ShouldBe((decimal)7829.2781);
            configuration.MixedAppGuid.ShouldBe(new Guid("0C76271C-BF3E-497E-96E5-840E2EC2FCCB"));
            configuration.MixedAppComplex.ShouldNotBeNull();
            configuration.MixedAppComplex.Id.ShouldBe(new Guid("EDB4B244-85DF-4135-9DE2-126CC30C8B2B"));
            configuration.MixedAppComplex.Name.ShouldBe("mixed-app-name");
            configuration.MixedAppComplex.Amount.ShouldBe((decimal)165.289);

            // Check all properties filled out from config.json
            configuration.MixedJsonString.ShouldBe("mixed-custom-json-string-value");
            configuration.MixedJsonBoolean.ShouldBeTrue();
            configuration.MixedJsonDecimal.ShouldBe((decimal)7829.2980);
            configuration.MixedJsonGuid.ShouldBe(new Guid("73AD6DC7-4865-441B-A84C-C2D6ED6D0E7D"));
            configuration.MixedJsonComplex.ShouldNotBeNull();
            configuration.MixedJsonComplex.Id.ShouldBe(new Guid("E62BB5BD-1800-4031-95B7-041C91384C0D"));
            configuration.MixedJsonComplex.Name.ShouldBe("mixed-custom-json-name");
            configuration.MixedJsonComplex.Amount.ShouldBe((decimal)9102.26783);
        }
    }
}