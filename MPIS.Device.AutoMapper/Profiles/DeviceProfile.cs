#region "Libraries"

using AutoMapper;
using MPIS.Device.AplicationService.DTOs.Device;
using MPIS.Device.DomainModel;

#endregion

namespace MPIS.Device.AutoMapper.Profiles
{
   public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<DomainModel.Device, CreateDeviceRequest>()
                .ForMember(dest => dest.TypeSO, opt => opt.MapFrom(src => (TypeSODTO)src.TypeSO)); ;
            CreateMap<CreateDeviceRequest, DomainModel.Device>()
                .ForMember(dest => dest.TypeSO, opt => opt.MapFrom(src => (TypeSO)src.TypeSO));
            CreateMap<DomainModel.Device, UpdateDeviceRequest>();
            CreateMap<UpdateDeviceRequest, DomainModel.Device>();
            CreateMap<DomainModel.Device, DeviceResponse>()
                .ForMember(dest => dest.TypeSO, opt => opt.MapFrom(src => (TypeSODTO)src.TypeSO));
            CreateMap<DeviceResponse, DomainModel.Device>();
            //CreateMap<CreateDeviceRequest, UserCreated>();
            //CreateMap<UpdateUserRequest, UserUpdated>();
            //CreateMap<DeleteUserByIdRequest, UserDeleted>();

            CreateMap<CreateDeviceRequest, DeviceResponse>();
            CreateMap<DeviceResponse, CreateDeviceRequest>();
        }
    }
}
