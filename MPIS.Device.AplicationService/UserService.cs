#region "Libraries"

using AutoMapper;
using MPIS.Device.AplicationService.Abstract;
using MPIS.Device.AplicationService.DTOs.User;
using MPIS.Device.Repository.Abstract;
using System;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.AplicationService
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateUserAsync(CreateUserRequest request)
        {
            var id = await _userRepository.CreateUserAsync(request);
            return id;
        }

        public async Task<bool> DeleteUserAsync(DeleteUserRequest request)
        {
            var result = await _userRepository.DeleteUserByIdAsync(request);
            return result;
        }

        public async Task<bool> UpdateUserAsync(UpdateUserRequest request)
        {
            var result = await _userRepository.UpdateUserAsync(request);
            return result;
        }
    }
}
