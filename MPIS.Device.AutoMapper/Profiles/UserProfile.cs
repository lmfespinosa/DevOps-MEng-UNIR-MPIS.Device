#region "Libraries"

using AutoMapper;
using MPIS.Device.AplicationService.DTOs.User;

#endregion

namespace MPIS.Device.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<DomainModel.User, CreateUserRequest>();
            CreateMap<CreateUserRequest, DomainModel.User>();
            CreateMap<DomainModel.User, UpdateUserRequest>();
            CreateMap<UpdateUserRequest, DomainModel.User>();
        }
    }
}
