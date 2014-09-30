//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using System;
using System.Web;
using System.Web.Http;

namespace FX.Configuration.WebAppSample
{
    /// <summary>
    /// The web application
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// Application starts
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}