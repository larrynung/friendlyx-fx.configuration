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
using System.Diagnostics;

namespace FX.Configuration.Tests
{
    /// <summary>
    /// A sub value type
    /// </summary>
    [DebuggerDisplay("{Expiration} {Amount}")]
    public class SubValue
    {
        /// <summary>
        /// Gets or sets the expiration - just a TimeSpan value
        /// </summary>
        public TimeSpan Expiration { get; set; }

        /// <summary>
        /// Gets or sets the amount - just a double value
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the complex type value
        /// </summary>
        public SubValue Value { get; set; }
    }

    /// <summary>
    /// A complex setting type used to verify how deserializers work
    /// </summary>
    [DebuggerDisplay("{Id} {Name}")]
    public class ComplexSettingValue
    {
        /// <summary>
        /// Gets or sets the name - just a string value
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier - just a Guid value
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the complex property - SubValue type
        /// </summary>
        public SubValue ComplexProperty { get; set; }
    }
}