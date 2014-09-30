//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using FX.Configuration.Attributes;

namespace FX.Configuration.ConsoleSample
{
    /// <summary>
    /// Main application configuration
    /// </summary>
    public class MainAppConfiguration : AppConfiguration
    {
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