A lightweight, simple, flexible, extensible library to read configurations using strongly typed classes.
- you can use a standard way to read configuration from app.config as well as from a pure JSON configuration file.
- you can also use a mix of various configuration sources like app.config and config.json (look at the MixedConfiguration class)

Usage samples can be found in FX.Configuration.ConsoleSample and FX.Configuration.WebAppSample.

## app.config
    <appSettings>
        <add key="DisplayName" value="some display name for the project"/>
        <add key="Count" value="278"/>
    </appSettings>

## MyConfiguration.cs
    /// <summary>
    /// My configuration with some simple properties
    /// </summary>
    public class MyConfiguration : AppConfiguration
    {
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public int Count { get; private set; }
    }

## Program.cs
    static void Main(string[] args)
    {
        // Create an instance
        MyConfiguration configuration = new MyConfiguration();

        // Now you can just read the properties
        Console.WriteLine("Display Name: " + configuration.DisplayName);
        Console.WriteLine("Count: " + configuration.Count);

        Console.ReadKey();
    }

## config.json
```json
{
    "AppVersion" : "0.3.0",
    "ComplexDetails" : {
        "DisplayName" : "some-json-with-display-name",
        "Expiration" : "2099-11-01T00:00:00",
        "SomeDetails" : {
            "Id" : "569efa2e-c315-426f-bc02-f76ab4e0eeda",
            "Name" : "this-sub-name-in-json",
            "Elapsed" : "1.10:04:19"
        }
    },
    "IntegerValues" : [190, 267, 33, -1],
    "PreprocessedSetting" : "some-setting-which-will-be-wrapped"
}
```

## MainJsonConfiguration.cs
    /// <summary>
    /// A sample of a json configuration
    /// </summary>
    public class MainJsonConfiguration : JsonConfiguration
    {
        /// <summary>
        /// Gets the application version
        /// </summary>
        public string AppVersion { get; set; }

        /// <summary>
        /// Gets the complex details
        /// </summary>
        public ConfigurationComplexDetails ComplexDetails { get; set; }

        /// <summary>
        /// Gets the integer values
        /// </summary>
        public List<int> IntegerValues { get; set; }

        /// <summary>
        /// Gets the preprocessed setting
        /// </summary>
        [MyCustomSettingPreprocessor]
        public string PreprocessedSetting { get; set; }
    }
	
## MyCustomSettingPreprocessorAttribute
    /// <summary>
    /// A custom preprocessor to process a setting value before it is set to the property
    /// </summary>
    public class MyCustomSettingPreprocessorAttribute : PreprocessAttribute
    {
        /// <summary>
        /// Preprocesses the specified setting value
        /// </summary>
        /// <param name="settingValue">The original setting value</param>
        /// <returns> A preprocessed value</returns>
        public override object Preprocess(object settingValue)
        {
            return string.Format("PREPROCESSED VALUE ***** {0}", settingValue);
        }
    }

## MainMixedConfiguration.cs
    /// <summary>
    /// Main mixed configuration to read values from app.config and config.json
    /// </summary>
    public class MainMixedConfiguration : MixedConfiguration
    {
        /// <summary>
        /// Gets a string setting value setting from app.config
        /// </summary>
        public string MixedAppString { get; private set; }

        /// <summary>
        /// Gets a boolean setting value setting from app.config
        /// </summary>
        public bool MixedAppBoolean { get; private set; }

        /// <summary>
        /// Gets a decimal setting value setting from app.config
        /// </summary>
        public decimal MixedAppDecimal { get; private set; }

        /// <summary>
        /// Gets a guid setting value setting from app.config
        /// </summary>
        public Guid MixedAppGuid { get; private set; }

        /// <summary>
        /// Gets a complex setting value setting from app.config
        /// </summary>
        public ComplexMixedProperty MixedAppComplex { get; private set; }

        /// <summary>
        /// Gets or sets a string setting value from config.json
        /// </summary>
        public string MixedJsonString { get; set; }

        /// <summary>
        /// Gets or sets a boolean setting value from config.json
        /// </summary>
        public bool MixedJsonBoolean { get; set; }

        /// <summary>
        /// Gets or sets a decimal setting value from config.json
        /// </summary>
        public decimal MixedJsonDecimal { get; set; }

        /// <summary>
        /// Gets or sets a guid setting value from config.json
        /// </summary>
        public Guid MixedJsonGuid { get; set; }

        /// <summary>
        /// Gets or sets a complex setting value from config.json
        /// </summary>
        public ComplexMixedProperty MixedJsonComplex { get; set; }
    }