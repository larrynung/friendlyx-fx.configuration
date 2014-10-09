A lightweight, simple, flexible, extensible library to read configurations using strongly typed classes.

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
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public int Count { get; set; }
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