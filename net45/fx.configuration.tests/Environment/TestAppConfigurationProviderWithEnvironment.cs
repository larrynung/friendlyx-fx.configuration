//---------------------------------------------------------
// Copyright© 2014 FriendlyX.  All rights reserved.
//---------------------------------------------------------

using FX.Configuration.Attributes;

namespace FX.Configuration.Tests.Environment
{
    /// <summary>
    /// Test app configuration provider for a particular environment
    /// </summary>
    [ConfigurationEnvironment("test")]
    [ConfigurationEnvironment("test2")]
    public class TestAppConfigurationProviderWithEnvironment : AppConfigurationProvider
    {
    }
}