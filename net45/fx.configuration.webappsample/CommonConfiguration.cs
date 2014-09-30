//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

namespace FX.Configuration.WebAppSample
{
    /// <summary>
    /// A common web app configuration
    /// </summary>
    public class CommonConfiguration : AppConfigurationShortMapping
    {
        /// <summary>
        /// Gets the name of the certificate
        /// </summary>
        public string CertificateName { get; private set; }

        /// <summary>
        /// Gets the certificates count
        /// </summary>
        public int CertificatesCount { get; private set; }
    }
}