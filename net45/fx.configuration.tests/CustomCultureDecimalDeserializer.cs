//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Globalization;
using FX.Configuration.Deserializers;

namespace FX.Configuration.Tests
{
    /// <summary>
    /// A custom deserializer
    /// </summary>
    internal class CustomCultureDecimalDeserializer : ISettingDeserializer<decimal>
    {
        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out decimal result)
        {
            result = Convert.ToDecimal(input, new CultureInfo("ru-RU"));
        }
    }
}