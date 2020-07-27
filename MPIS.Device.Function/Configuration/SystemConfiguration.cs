#region "Libraries"

using Microsoft.Extensions.Configuration;

#endregion

namespace MPIS.Device.Function.Configuration
{
    public class SystemConfiguration
    {
        private readonly IConfigurationRoot _configurationRoot;

        public SystemConfiguration(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }
    }
}
