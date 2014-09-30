//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

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
    }
}