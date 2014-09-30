//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;

namespace FX.Configuration.ConsoleSample
{
    /// <summary>
    /// Configuration complex details object
    /// </summary>
    public class ConfigurationComplexDetails
    {
        /// <summary>
        /// Gets or sets the display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the expiration
        /// </summary>
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Gets or sets some details
        /// </summary>
        public SomeSubDetails SomeDetails { get; set; }
    }
}