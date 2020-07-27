#region "Libraires"

using AutoMapper;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using MPIS.Device.AutoMapper.Profiles;
using System.Reflection;

#endregion

namespace MPIS.Device.AutoMapper.Configuration
{
    public static class MapperExtension
    {
        public static void AddAutomapperService(this IFunctionsHostBuilder builder)
        {
            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(UserProfile)));
            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(DeviceProfile)));
            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(HardwareProfile)));
            builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(SoftwareProfile)));
        }
    }
}
