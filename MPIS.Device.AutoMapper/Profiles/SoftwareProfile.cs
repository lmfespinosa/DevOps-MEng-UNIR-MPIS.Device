#region "Libraries"

using AutoMapper;
using MPIS.Device.AplicationService.DTOs.Software;

#endregion

namespace MPIS.Device.AutoMapper.Profiles
{
    public class SoftwareProfile : Profile
    {
        public SoftwareProfile()
        {
            CreateMap<DomainModel.Software, CreateSoftwareRequest>();
            CreateMap<CreateSoftwareRequest, DomainModel.Software>();
            CreateMap<DomainModel.Software, UpdateSoftwareRequest>();
            CreateMap<UpdateSoftwareRequest, DomainModel.Software>();
            CreateMap<DomainModel.Software, SoftwareResponse>();
            CreateMap<SoftwareResponse, DomainModel.Software>();
            //CreateMap<CreateDeviceRequest, UserCreated>();
            //CreateMap<UpdateUserRequest, UserUpdated>();
            //CreateMap<DeleteUserByIdRequest, UserDeleted>();

            CreateMap<CreateSoftwareRequest, SoftwareResponse>();
            CreateMap<SoftwareResponse, CreateSoftwareRequest>();
        }
    }
}
