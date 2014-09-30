//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Collections.Generic;
using FX.Configuration.Attributes;
using FX.Configuration.Deserializers;

namespace FX.Configuration.Tests
{
    /// <summary>
    /// A configuration used in unit tests
    /// </summary>
    internal class TestAppConfiguration : AppConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestAppConfiguration"/> class.
        /// </summary>
        public TestAppConfiguration()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestAppConfiguration"/> class.
        /// </summary>
        /// <param name="configurationProviders">The configuration providers.</param>
        public TestAppConfiguration(IEnumerable<IConfigurationProvider> configurationProviders)
            : base(configurationProviders)
        {
        }

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

        /// <summary>
        /// Gets the decimal property with custom culture
        /// </summary>
        [CustomCulture("ru-RU")]
        public decimal DecimalPropertyWithCustomCulture { get; private set; }

        /// <summary>
        /// Gets the decimal property in custom culture
        /// </summary>
        public decimal DecimalPropertyInCustomCulture { get; private set; }

        /// <summary>
        /// Gets the decimal with custom deserializer specified
        /// </summary>
        [Deserializer(typeof(CustomCultureDecimalDeserializer))]
        public decimal DecimalWithCustomDeserializer { get; private set; }

        /// <summary>
        /// Gets some complex value
        /// </summary>
        [Deserializer(typeof(JsonDeserializer))]
        public ComplexSettingValue SomeComplexProperty { get; private set; }

        /// <summary>
        /// Gets another complex property
        /// </summary>
        [JsonSetting]
        public ComplexSettingValue AnotherComplexProperty { get; private set; }
    }
}