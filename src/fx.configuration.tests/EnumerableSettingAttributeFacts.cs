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
    /// Unit tests for the EnumerableSettingAttribute class
    /// </summary>
    public class EnumerableSettingAttributeFacts
    {
        /// <summary>
        /// Reads the enumerable setting with all defaults correctly
        /// </summary>
        [Fact]
        public void ReadsEnumerableSettingWithDefaultsCorrectly()
        {
            // Arrange
            CurrentConfigurationEnvironment.Name = null;
            TestAppConfigurationEnumerableSetting configuration = new TestAppConfigurationEnumerableSetting();

            // Assert
            configuration.StringList.ShouldNotBeNull();
            configuration.StringList.Count.ShouldBe(3);
            configuration.StringList[0].ShouldBe("item2");
            configuration.StringList[1].ShouldBe("item1");
            configuration.StringList[2].ShouldBe("item289");

            configuration.GuidList.ShouldNotBeNull();
            configuration.GuidList.Count.ShouldBe(4);
            configuration.GuidList[0].ShouldBe(new Guid("30E392D3-76E9-4D18-BDB1-A786DBB55EAC"));
            configuration.GuidList[1].ShouldBe(new Guid("EC27E68D-B11E-4AEC-AB82-BC29B3F2DEA1"));
            configuration.GuidList[2].ShouldBe(new Guid("7B97D63F-8251-41BD-A734-91B89305D6B4"));
            configuration.GuidList[3].ShouldBe(new Guid("2773C59A-5502-43C0-B573-E8D7D4E1E3DE"));
        }
    }
}