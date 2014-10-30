/* The MIT License (MIT)
*
* Copyright (c) 2014 FriendlyX
* Permission is hereby granted, free of charge, to any person obtaining a copy of
* this software and associated documentation files (the "Software"), to deal in
* the Software without restriction, including without limitation the rights to
* use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
* the Software, and to permit persons to whom the Software is furnished to do so,
* subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
* FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
* COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
* IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
* CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FX.Configuration
{
    /// <summary>
    /// A configuration provider based on a JSON file
    /// </summary>
    public class JsonConfigurationProvider : BaseConfigurationProvider
    {
        /// <summary>
        /// The default configuration file name
        /// </summary>
        public const string DefaultConfigFileName = "config.json";

        private volatile JObject configurationObject;
        private readonly object readConfigSync = new object();

        private JObject GetConfigObject()
        {
            if (this.configurationObject == null)
            {
                lock (this.readConfigSync)
                {
                    if (this.configurationObject == null)
                    {
                        string json = ReadJsonFromConfigFile();
                        JObject jObject = (JObject)JsonConvert.DeserializeObject(json);
                        this.configurationObject = jObject;
                    }
                }
            }

            return this.configurationObject;
        }

        private string ReadJsonFromConfigFile()
        {
            return File.ReadAllText(this.JsonConfigFileName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonConfigurationProvider"/> class.
        /// The default 'config.json' will be used
        /// </summary>
        public JsonConfigurationProvider()
            : this(DefaultConfigFileName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonConfigurationProvider"/> class.
        /// </summary>
        /// <param name="jsonConfigFileName">Name of the json configuration file.</param>
        public JsonConfigurationProvider(string jsonConfigFileName)
        {
            this.JsonConfigFileName = jsonConfigFileName;
        }

        /// <summary>
        /// Gets the name of the json configuration file
        /// </summary>
        public string JsonConfigFileName { get; private set; }

        /// <summary>
        /// Tries the get a value
        /// </summary>
        /// <param name="settingName">Name of the setting</param>
        /// <param name="rawValue">The raw value</param>
        /// <returns>True is the setting was found</returns>
        protected override bool TryGetSettingValue(string settingName, out object rawValue)
        {
            JObject jObject = this.GetConfigObject();

            JToken token;
            bool isDone = jObject.TryGetValue(settingName, StringComparison.OrdinalIgnoreCase, out token);

            if (isDone)
            {
                // Extract the value
                JValue value = token as JValue;
                if (value != null)
                {
                    rawValue = value.Value;
                }
                else
                {
                    JObject objectValue = token as JObject;
                    if (objectValue != null)
                    {
                        rawValue = objectValue;
                    }
                    else
                    {
                        JArray arrayValue = token as JArray;
                        rawValue = arrayValue;
                    }
                }
            }
            else
            {
                rawValue = null;
            }

            return isDone;
        }
    }
}