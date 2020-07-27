#region "Libraries"

using AutoMapper;
using MPIS.Device.AplicationService.DTOs.OperativeSystem;

#endregion

namespace MPIS.Device.AutoMapper.Profiles
{
    public class OperativeSystemProfile : Profile
    {
        public OperativeSystemProfile()
        {
            CreateMap<DomainModel.OperativeSystem, CreateOperativeSystemRequest>();
            CreateMap<CreateOperativeSystemRequest, DomainModel.OperativeSystem>();
            CreateMap<DomainModel.OperativeSystem, UpdateOperativeSystemRequest>();
            CreateMap<UpdateOperativeSystemRequest, DomainModel.OperativeSystem>();
            CreateMap<DomainModel.OperativeSystem, OperativeSystemResponse>();
            CreateMap<OperativeSystemResponse, DomainModel.OperativeSystem>();
            //CreateMap<CreateDeviceRequest, UserCreated>();
            //CreateMap<UpdateUserRequest, UserUpdated>();
            //CreateMap<DeleteUserByIdRequest, UserDeleted>();

            CreateMap<CreateOperativeSystemRequest, OperativeSystemResponse>();
            CreateMap<OperativeSystemResponse, CreateOperativeSystemRequest>();
        }
    }
}
