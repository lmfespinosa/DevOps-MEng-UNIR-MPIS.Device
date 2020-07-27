#region "Libraries"

using AutoMapper;
using MPIS.Device.AplicationService.DTOs.Hardware;
using MPIS.Device.DomainModel;

#endregion

namespace MPIS.Device.AutoMapper.Profiles
{
    public class HardwareProfile : Profile
    {
        public HardwareProfile()
        {
            CreateMap<DomainModel.Hardware, CreateHardwareRequest>()
                .ForMember(dest => dest.TypeHardware, opt => opt.MapFrom(src => (TypeHardwareDTO)src.TypeHardware)); ;
            CreateMap<CreateHardwareRequest, DomainModel.Hardware>()
                .ForMember(dest => dest.TypeHardware, opt => opt.MapFrom(src => (TypeHardware)src.TypeHardware));
            CreateMap<DomainModel.Hardware, UpdateHardwareRequest>();
            CreateMap<UpdateHardwareRequest, DomainModel.Hardware>();
            CreateMap<DomainModel.Hardware, HardwareResponse>()
                .ForMember(dest => dest.TypeHardware, opt => opt.MapFrom(src => (TypeHardwareDTO)src.TypeHardware));
            CreateMap<HardwareResponse, DomainModel.Hardware>();
            //CreateMap<CreateDeviceRequest, UserCreated>();
            //CreateMap<UpdateUserRequest, UserUpdated>();
            //CreateMap<DeleteUserByIdRequest, UserDeleted>();

            CreateMap<CreateHardwareRequest, HardwareResponse>();
            CreateMap<HardwareResponse, CreateHardwareRequest>();
        }
    }
}
