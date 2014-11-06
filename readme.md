A lightweight, simple, flexible, extensible library to read configurations using strongly typed classes.

- you can use a standard way to read configuration from app.config as well as from a pure JSON configuration file

- you can also use a mix of various configuration sources like app.config and config.json (look at the MixedConfiguration class)

Usage samples can be found in FX.Configuration.ConsoleSample and FX.Configuration.WebAppSample.

## app.config
    <appSettings>
        <add key="DisplayName" value="some display name for the project"/>
        <add key="Count" value="278"/>
    </appSettings>

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

## MyConfiguration.cs
    public class MyConfiguration : AppConfiguration
    {
        public string DisplayName { get; private set; }

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

## MainJsonConfiguration.cs
    public class MainJsonConfiguration : JsonConfiguration
    {
        public string AppVersion { get; set; }

        public ConfigurationComplexDetails ComplexDetails { get; set; }

        public List<int> IntegerValues { get; set; }

        [MyCustomSettingPreprocessor]
        public string PreprocessedSetting { get; set; }
    }
	
## MyCustomSettingPreprocessorAttribute
    public class MyCustomSettingPreprocessorAttribute : PreprocessAttribute
    {
        public override object Preprocess(object settingValue)
        {
            return string.Format("PREPROCESSED VALUE ***** {0}", settingValue);
        }
    }

## MainMixedConfiguration.cs
    public class MainMixedConfiguration : MixedConfiguration
    {
        public string MixedAppString { get; private set; }

        public bool MixedAppBoolean { get; private set; }

        public decimal MixedAppDecimal { get; private set; }

        public Guid MixedAppGuid { get; private set; }

        public ComplexMixedProperty MixedAppComplex { get; private set; }

        public string MixedJsonString { get; set; }

        public bool MixedJsonBoolean { get; set; }

        public decimal MixedJsonDecimal { get; set; }

        public Guid MixedJsonGuid { get; set; }

        public ComplexMixedProperty MixedJsonComplex { get; set; }
    }
	
##MixedWebConfiguration.cs
    public class MixedWebConfiguration : MixedConfiguration
    {
        public MixedWebConfiguration()
            : base(HttpContext.Current.Server.MapPath("~/config.json"))
        {
        }

        public string Url { get; set; }

        public string Database { get; set; }
    }