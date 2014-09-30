//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Globalization;

namespace FX.Configuration.Deserializers
{
    /// <summary>
    /// Deserializes a raw setting to a typed value
    /// </summary>
    public interface ISettingDeserializer<T>
    {
        ///// <summary>
        ///// Deserializes the specified input value to a typed value
        ///// </summary>
        ///// <param name="input">The input value</param>
        ///// <param name="result">The result value</param>
        ///// <returns>The deserialized value</returns>
        ////void Deserialize(object input, out T result);

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out T result);
    }
}