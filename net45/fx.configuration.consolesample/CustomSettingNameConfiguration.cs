//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using FX.Configuration.Attributes;

namespace FX.Configuration.ConsoleSample
{
    /// <summary>
    /// A custom setting name configuration
    /// </summary>
    public class CustomSettingNameConfiguration : AppConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomSettingNameConfiguration"/> class.
        /// </summary>
        public CustomSettingNameConfiguration()
            : base(new [] { new AppConfigurationProvider(new CustomSettingNameResolver()) })
        {
        }

        /// <summary>
        /// Gets the application version
        /// </summary>
        public string AppVersion { get; private set; }

        /// <summary>
        /// Gets the complex details
        /// </summary>
        [JsonSetting]
        public ConfigurationComplexDetails ComplexDetails { get; private set; }
    }
}