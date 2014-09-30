//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;

namespace FX.Configuration.Attributes
{
    /// <summary>
    /// A custom culture attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CustomCultureAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCultureAttribute"/> class.
        /// </summary>
        /// <param name="cultureCode">The culture code</param>
        public CustomCultureAttribute(string cultureCode)
        {
            this.CultureCode = cultureCode;
        }

        /// <summary>
        /// Gets the culture code
        /// </summary>
        public string CultureCode { get; private set; }
    }
}