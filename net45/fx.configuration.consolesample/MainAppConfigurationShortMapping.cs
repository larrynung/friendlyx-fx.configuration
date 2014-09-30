//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using FX.Configuration.Attributes;

namespace FX.Configuration.ConsoleSample
{
    /// <summary>
    /// Main application configuration with short property names mapping
    /// </summary>
    public class MainAppConfigurationShortMapping : AppConfigurationShortMapping
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