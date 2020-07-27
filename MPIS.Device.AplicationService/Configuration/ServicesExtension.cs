#region "Libraries"

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MPIS.Device.AplicationService.Abstract;

#endregion

namespace MPIS.Device.AplicationService.Configuration
{
    public static class ServicesExtension
    {
        public static void AddDeviceServices(this IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<IDeviceService, DeviceService>();
            builder.Services.AddTransient<IHardwareService, HardwareService>();
            builder.Services.AddTransient<ISoftwareService, SoftwareService>();
            builder.Services.AddTransient<IOperativeSystemService, OperativeSystemService>();
        }
    }
}
