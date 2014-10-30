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
    /// Unit tests for the JsonConfiguration class
    /// </summary>
    public class JsonConfigurationFacts
    {
        /// <summary>
        /// A json configuration fills correctly
        /// </summary>
        [Fact]
        public void JsonConfigurationFillsCorrectly()
        {
            // Arrange
            TestJsonConfiguration configuration = new TestJsonConfiguration();

            // Assert
            configuration.StringProperty.ShouldBe("some-string-property-value");
            configuration.TimeSpanProperty.ShouldBe(TimeSpan.Parse("11:21:19.2789"));
            configuration.BoolProperty.ShouldBe(true);
            configuration.GuidProperty.ShouldBe(new Guid("C002F77E-55F6-491E-AF64-C70EC85FEE09"));

            configuration.ComplexProperty.Id.ShouldBe(new Guid("845BE577-33D3-4FF7-B114-75C337C4B449"));
            configuration.ComplexProperty.Name.ShouldBe("this-my-name");
            configuration.ComplexProperty.Amount.ShouldBe((float)102.389);

            configuration.IntegerValues.Count.ShouldBe(4);
            configuration.IntegerValues[0].ShouldBe(190);
            configuration.IntegerValues[1].ShouldBe(267);
            configuration.IntegerValues[2].ShouldBe(33);
            configuration.IntegerValues[3].ShouldBe(-1);
        }

        /// <summary>
        /// A json configuration fills correctly from a custom json file
        /// </summary>
        [Fact]
        public void JsonConfigurationFillsCorrectlyFromCustomFile()
        {
            // Arrange
            TestJsonConfiguration configuration = new TestJsonConfiguration("customConfig.json");

            // Assert
            configuration.StringProperty.ShouldBe("some--custom-string-property-value");
            configuration.TimeSpanProperty.ShouldBe(TimeSpan.Parse("7:11:21.672"));
            configuration.BoolProperty.ShouldBe(true);
            configuration.GuidProperty.ShouldBe(new Guid("2D4B0F2E-667C-4F7D-BF9E-862BA94F8ACB"));

            configuration.ComplexProperty.Id.ShouldBe(new Guid("3EC9E8E7-1649-457A-AB5A-9C7637B8EED6"));
            configuration.ComplexProperty.Name.ShouldBe("this-my-custom-name");
            configuration.ComplexProperty.Amount.ShouldBe((float)2678.1672);

            configuration.IntegerValues.Count.ShouldBe(4);
            configuration.IntegerValues[0].ShouldBe(23);
            configuration.IntegerValues[1].ShouldBe(823);
            configuration.IntegerValues[2].ShouldBe(-387);
            configuration.IntegerValues[3].ShouldBe(921);
        }
    }
}