#region "Libraries"

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using MPIS.Device.AplicationService.Configuration;
using MPIS.Device.AutoMapper.Configuration;
using MPIS.Device.EventGrid.Configuration;
using MPIS.Device.Function;
using MPIS.Device.Function.Configuration;
using MPIS.Device.Repository.Configuration;

#endregion

[assembly: FunctionsStartup(typeof(Startup))]
namespace MPIS.Device.Function
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.AddConfiguration();
            builder.AddAutomapperService();
            builder.AddPersistenceService();
            builder.AddDeviceServices();
            builder.AddEventGridService();
        }
    }
}
