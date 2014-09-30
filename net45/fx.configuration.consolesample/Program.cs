//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using Autofac;
using Newtonsoft.Json;

namespace FX.Configuration.ConsoleSample
{
    /// <summary>
    /// A startup class
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            // Using Autofac sample
            Console.WriteLine("**************** Autofac sample");
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule<ConsoleAppAutofacModule>();
            IContainer container = builder.Build();
            MainAppConfiguration configuration = container.Resolve<MainAppConfiguration>();
            DumpConfiguration(configuration);

            // Manual configuration creation sample
            Console.WriteLine("**************** Manual sample");
            configuration = new MainAppConfiguration();
            DumpConfiguration(configuration);

            // Using Autofac sample with short properties mapping
            Console.WriteLine("**************** Autofac sample (short mapping)");
            MainAppConfigurationShortMapping configurationShortMapping = container.Resolve<MainAppConfigurationShortMapping>();
            DumpConfiguration(configurationShortMapping);

            // Manual configuration creation sample with short properties mapping
            Console.WriteLine("**************** Manual sample (short mapping)");
            configurationShortMapping = new MainAppConfigurationShortMapping();
            DumpConfiguration(configurationShortMapping);

            // Using Autofac sample with custom properties mapping
            Console.WriteLine("**************** Autofac sample (custom mapping)");
            CustomSettingNameConfiguration customSettingNameConfiguration = container.Resolve<CustomSettingNameConfiguration>();
            DumpConfiguration(customSettingNameConfiguration);

            // Manual configuration creation sample with custom properties mapping
            Console.WriteLine("**************** Manual sample (custom mapping)");
            customSettingNameConfiguration = new CustomSettingNameConfiguration();
            DumpConfiguration(customSettingNameConfiguration);

            Console.ReadKey();
        }

        private static void DumpConfiguration(MainAppConfigurationShortMapping configuration)
        {
            Console.WriteLine("AppVersion: " + configuration.AppVersion);
            Console.WriteLine("ComplexDetails.DisplayName: " + configuration.ComplexDetails.DisplayName);
            Console.WriteLine("ComplexDetails.Expiration: " + configuration.ComplexDetails.Expiration);
            Console.WriteLine("ComplexDetails.SomeDetails.Id: " + configuration.ComplexDetails.SomeDetails.Id);
            Console.WriteLine("ComplexDetails.SomeDetails.Name: " + configuration.ComplexDetails.SomeDetails.Name);
            Console.WriteLine("ComplexDetails.SomeDetails.Elapsed: " + configuration.ComplexDetails.SomeDetails.Elapsed);

            string json = JsonConvert.SerializeObject(configuration.ComplexDetails);
            Console.WriteLine("ComplexDetails JSON: " + json);
        }

        private static void DumpConfiguration(MainAppConfiguration configuration)
        {
            Console.WriteLine("AppVersion: " + configuration.AppVersion);
            Console.WriteLine("ComplexDetails.DisplayName: " + configuration.ComplexDetails.DisplayName);
            Console.WriteLine("ComplexDetails.Expiration: " + configuration.ComplexDetails.Expiration);
            Console.WriteLine("ComplexDetails.SomeDetails.Id: " + configuration.ComplexDetails.SomeDetails.Id);
            Console.WriteLine("ComplexDetails.SomeDetails.Name: " + configuration.ComplexDetails.SomeDetails.Name);
            Console.WriteLine("ComplexDetails.SomeDetails.Elapsed: " + configuration.ComplexDetails.SomeDetails.Elapsed);

            string json = JsonConvert.SerializeObject(configuration.ComplexDetails);
            Console.WriteLine("ComplexDetails JSON: " + json);
        }

        private static void DumpConfiguration(CustomSettingNameConfiguration configuration)
        {
            Console.WriteLine("AppVersion: " + configuration.AppVersion);
            Console.WriteLine("ComplexDetails.DisplayName: " + configuration.ComplexDetails.DisplayName);
            Console.WriteLine("ComplexDetails.Expiration: " + configuration.ComplexDetails.Expiration);
            Console.WriteLine("ComplexDetails.SomeDetails.Id: " + configuration.ComplexDetails.SomeDetails.Id);
            Console.WriteLine("ComplexDetails.SomeDetails.Name: " + configuration.ComplexDetails.SomeDetails.Name);
            Console.WriteLine("ComplexDetails.SomeDetails.Elapsed: " + configuration.ComplexDetails.SomeDetails.Elapsed);

            string json = JsonConvert.SerializeObject(configuration.ComplexDetails);
            Console.WriteLine("ComplexDetails JSON: " + json);
        }
    }
}