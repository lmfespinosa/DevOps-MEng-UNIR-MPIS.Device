using MPIS.Device.AplicationService.DTOs.Device;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPIS.Device.AplicationService.Abstract
{
    public interface IDeviceService
    {
        Task<Guid> CreateDeviceAsync(CreateDeviceRequest request);
        Task<bool> UpdateDeviceAsync(UpdateDeviceRequest request);
        Task<bool> DeleteDeviceByIdAsync(DeleteDeviceByIdRequest request);
        //Task<List<DevicesResponse>> GetAllAvailableUsersAsync();
        Task<DeviceResponse> GetDeviceByIdAsync(GetDeviceByIdRequest request);
        Task<List<DeviceResponse>> GetAllDeviceByEmailUserAsync(GetDeviceByEmailUserRequest request);
    }
}
