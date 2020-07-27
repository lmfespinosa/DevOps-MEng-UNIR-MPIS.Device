#region "Libraries"

using AutoMapper;
using MPIS.Device.AutoMapper.Profiles;

#endregion

namespace MPIS.Device.Function.Unit.Tests.Settings
{
    public class AutomapperSingleton
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    // Auto Mapper Configurations
                    var mappingConfig = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new UserProfile());
                        mc.AddProfile(new DeviceProfile());
                        mc.AddProfile(new HardwareProfile());
                        mc.AddProfile(new OperativeSystemProfile());
                        mc.AddProfile(new SoftwareProfile());
                    });

                    IMapper mapper = mappingConfig.CreateMapper();
                    _mapper = mapper;
                }

                return _mapper;
            }
        }
    }
}
