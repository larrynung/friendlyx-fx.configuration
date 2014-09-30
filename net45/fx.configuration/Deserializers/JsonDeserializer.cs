//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Globalization;
using Newtonsoft.Json;

namespace FX.Configuration.Deserializers
{
    /// <summary>
    /// JSON deserializer
    /// </summary>
    public class JsonDeserializer : ISettingDeserializer<object>
    {
        /// <summary>
        /// Gets the serializer settings
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <returns>The JSON serializer settings</returns>
        protected virtual JsonSerializerSettings GetSerializerSettings(object input, CultureInfo cultureInfo)
        {
            JsonSerializerSettings settings;

            if (cultureInfo != null)
            {
                settings = new JsonSerializerSettings
                {
                    Culture = cultureInfo,
                };
            }
            else
            {
                settings = null;
            }

            return settings;
        }

        /// <summary>
        /// Deserializes the specified input value to a typed value
        /// </summary>
        /// <param name="input">The input value</param>
        /// <param name="outputType">Type of the output</param>
        /// <param name="cultureInfo">The culture information</param>
        /// <param name="result">The result value</param>
        public void Deserialize(object input, Type outputType, CultureInfo cultureInfo, out object result)
        {
            if ((input as string) == null)
            {
                result = null;
            }
            else
            {
                JsonSerializerSettings settings = this.GetSerializerSettings(input, cultureInfo);
                result = JsonConvert.DeserializeObject((string)input, outputType, settings);
            }
        }
    }
}