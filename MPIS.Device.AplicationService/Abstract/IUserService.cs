#region "Libraries"

using MPIS.Device.AplicationService.DTOs.User;
using System;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.AplicationService.Abstract
{
    public interface IUserService
    {
        Task<Guid> CreateUserAsync(CreateUserRequest request);
        Task<bool> UpdateUserAsync(UpdateUserRequest request);
        Task<bool> DeleteUserAsync(DeleteUserRequest request);
    }
}
