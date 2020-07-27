#region "Libraries"

using MPIS.Device.AplicationService.DTOs.User;
using System;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Repository.Abstract
{
    public interface IUserRepository
    {
        Task<Guid> CreateUserAsync(CreateUserRequest request);
        Task<bool> UpdateUserAsync(UpdateUserRequest request);
        Task<bool> DeleteUserByIdAsync(DeleteUserRequest request);
    }
}
