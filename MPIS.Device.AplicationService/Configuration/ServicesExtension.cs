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
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IDeviceService, DeviceService>();
            builder.Services.AddScoped<IHardwareService, HardwareService>();
            builder.Services.AddScoped<ISoftwareService, SoftwareService>();
            builder.Services.AddScoped<IOperativeSystemService, OperativeSystemService>();
        }
    }
}
