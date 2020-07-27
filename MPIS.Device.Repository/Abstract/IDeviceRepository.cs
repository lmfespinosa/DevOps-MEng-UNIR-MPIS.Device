#region "Libraries"

using MPIS.Device.AplicationService.DTOs.Device;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Repository.Abstract
{
    public interface IDeviceRepository
    {
        Task<Guid> CreateDeviceAsync(CreateDeviceRequest request);
        Task<bool> UpdateDeviceAsync(UpdateDeviceRequest request);
        Task<bool> DeleteDeviceByIdAsync(DeleteDeviceByIdRequest request);
        //Task<List<DevicesResponse>> GetAllAvailableUsersAsync();
        Task<DeviceResponse> GetDeviceByIdAsync(GetDeviceByIdRequest request);
        Task<List<DeviceResponse>> GetAllDeviceByEmailUserAsync(GetDeviceByEmailUserRequest request);
    }
}
