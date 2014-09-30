//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Globalization;

namespace FX.Configuration
{
    /// <summary>
    /// Extension methods for .NET Framework compatibility
    /// </summary>
    internal static class RootCompatibilityExtensions
    {
        /// <summary>
        /// Parses the specified input
        /// </summary>
        /// <param name="input">The input string value</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <returns>The TimeSpan value</returns>
        public static TimeSpan Parse(this string input, CultureInfo cultureInfo)
        {
            return TimeSpan.Parse(input);
        }
    }
}