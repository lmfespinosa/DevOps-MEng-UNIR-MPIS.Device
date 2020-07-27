using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPIS.Device.Function.Integration.Tests.Settings
{
    public static class ConfigurationHelper
    {
        #region "Atributes"

        private static Settings _settings;

        #endregion "Atributes"

        #region "Properties"

        public static Settings Settings
        {
            get
            {
                if (_settings != null)
                {
                    return _settings;
                }


                var configurationRoot = new ConfigurationBuilder()
                    .AddJsonFile("local.integration.settings.json")
                    .AddEnvironmentVariables()
                    .Build();
                _settings = new Settings();
                configurationRoot.Bind(_settings);

                return _settings;
            }
        }

        #endregion "Properties"
    }
}
