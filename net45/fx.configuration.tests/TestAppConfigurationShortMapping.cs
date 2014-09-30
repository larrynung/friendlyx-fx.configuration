//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using FX.Configuration.Attributes;
using FX.Configuration.Deserializers;

namespace FX.Configuration.Tests
{
    /// <summary>
    /// A configuration with short mapping used in unit tests
    /// </summary>
    public class TestAppConfigurationShortMapping : AppConfigurationShortMapping
    {
        /// <summary>
        /// Gets the test property value
        /// </summary>
        public string StringProperty { get; private set; }

        /// <summary>
        /// Gets a boolean property
        /// </summary>
        public bool BoolProperty { get; private set; }

        /// <summary>
        /// Gets the unique identifier property
        /// </summary>
        public Guid GuidProperty { get; private set; }

        /// <summary>
        /// Gets the time span property
        /// </summary>
        public TimeSpan TimeSpanProperty { get; private set; }

        /// <summary>
        /// Gets the simple decimal property
        /// </summary>
        public decimal DecimalProperty { get; private set; }

        [Deserializer(typeof(JsonDeserializer))]
        public ComplexSettingValue SomeComplexProperty { get; private set; }
    }
}