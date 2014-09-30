//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;

namespace FX.Configuration.ConsoleSample
{
    /// <summary>
    /// Some object in a configuration
    /// </summary>
    public class SomeSubDetails
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the elapsed value
        /// </summary>
        public TimeSpan Elapsed { get; set; }
    }
}