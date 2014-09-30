//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;

namespace FX.Configuration
{
    /// <summary>
    /// A configuration provider
    /// </summary>
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Fills the configuration
        /// </summary>
        /// <typeparam name="T">The type of the configuration</typeparam>
        void Fill<T>(T config) where T : BaseConfiguration;
    }
}