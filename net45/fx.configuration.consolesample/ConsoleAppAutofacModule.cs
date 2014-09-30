//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using Autofac;
using FX.Configuration.Deserializers;

namespace FX.Configuration.ConsoleSample
{
    /// <summary>
    /// A console app Autofac module
    /// </summary>
    public class ConsoleAppAutofacModule : Module
    {
        /// <summary>
        /// Override to add registrations to the container.
        /// </summary>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DefaultDeserializer>().As<object>();
            builder.RegisterType<MainAppConfiguration>();
            builder.RegisterType<MainAppConfigurationShortMapping>();
            builder.RegisterType<CustomSettingNameConfiguration>();

            base.Load(builder);
        }
    }
}