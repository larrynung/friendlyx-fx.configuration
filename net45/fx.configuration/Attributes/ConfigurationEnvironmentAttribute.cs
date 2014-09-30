//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;

namespace FX.Configuration.Attributes
{
    /// <summary>
    /// An attribute defines which environment the provider is applicable in
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ConfigurationEnvironmentAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationEnvironmentAttribute"/> class.
        /// </summary>
        /// <param name="environmentName">Name of the environment</param>
        public ConfigurationEnvironmentAttribute(string environmentName)
        {
            this.Name = environmentName;
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; private set; }
    }
}