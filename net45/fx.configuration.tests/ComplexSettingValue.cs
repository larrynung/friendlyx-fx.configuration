//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

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