A lightweight, simple, flexible, extensible configuration library.

Usage samples can be found in FX.Configuration.ConsoleSample and FX.Configuration.WebAppSample.

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

    CustomSettingNameConfiguration customSettingNameConfiguration = new CustomSettingNameConfiguration();
    // Now you can use the fulfilled configuration instance!