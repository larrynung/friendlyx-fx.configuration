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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Results;

namespace FX.Configuration.WebAppSample.Controllers
{
    /// <summary>
    /// The configuration controller
    /// </summary>
    public class ConfigurationController : ApiController
    {
        private readonly CommonConfiguration commonConfiguration = new CommonConfiguration();
        private readonly CommonJsonConfiguration commonJsonConfiguration = new CommonJsonConfiguration();
        private readonly CommonMixedConfiguration commonMixedConfiguration = new CommonMixedConfiguration();

        /// <summary>
        /// Gets the configuration value
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>The result</returns>
        [HttpGet]
        [Route("api/configuration/{propertyName}")]
        public IHttpActionResult GetConfiguration(string propertyName)
        {
            IHttpActionResult result;
            PropertyInfo foundProperty = typeof(CommonConfiguration).GetProperties().FirstOrDefault(info => string.Equals(info.Name, propertyName, StringComparison.OrdinalIgnoreCase));
            if (foundProperty != null)
            {
                result = new ResponseMessageResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(foundProperty.GetValue(this.commonConfiguration).ToString())
                });
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Property not found. Property name: {0}", propertyName))
                });
            }

            return result;
        }

        /// <summary>
        /// Gets the configuration value from a json config
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>The result</returns>
        [HttpGet]
        [Route("api/jsonconfiguration/{propertyName}")]
        public IHttpActionResult GetJsonConfiguration(string propertyName)
        {
            IHttpActionResult result;
            PropertyInfo foundProperty = typeof(CommonJsonConfiguration).GetProperties().FirstOrDefault(info => string.Equals(info.Name, propertyName, StringComparison.OrdinalIgnoreCase));
            if (foundProperty != null)
            {
                result = new ResponseMessageResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(foundProperty.GetValue(this.commonJsonConfiguration).ToString())
                });
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Property not found. Property name: {0}", propertyName))
                });
            }

            return result;
        }

        /// <summary>
        /// Gets the configuration value from a json config
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>The result</returns>
        [HttpGet]
        [Route("api/mixedconfiguration/{propertyName}")]
        public IHttpActionResult GetMixedConfiguration(string propertyName)
        {
            IHttpActionResult result;
            PropertyInfo foundProperty = typeof(CommonMixedConfiguration).GetProperties().FirstOrDefault(info => string.Equals(info.Name, propertyName, StringComparison.OrdinalIgnoreCase));
            if (foundProperty != null)
            {
                result = new ResponseMessageResult(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(foundProperty.GetValue(this.commonMixedConfiguration).ToString())
                });
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(string.Format("Property not found. Property name: {0}", propertyName))
                });
            }

            return result;
        }
    }
}