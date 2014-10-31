A lightweight, simple, flexible, extensible library to read configurations using strongly typed classes.
You can use a standard way to read configuration from app.config as well as from a pure JSON configuration file.

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