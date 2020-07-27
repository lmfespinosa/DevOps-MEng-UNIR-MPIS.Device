using MPIS.Device.AplicationService.DTOs.Hardware;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPIS.Device.AplicationService.Abstract
{
    public interface IHardwareService
    {
        Task<Guid> CreateHardwareAsync(CreateHardwareRequest request);
        Task<bool> UpdateHardwareAsync(UpdateHardwareRequest request);
        Task<bool> DeleteHardwareByIdAsync(DeleteHardwareByIdRequest request);
        //Task<List<DevicesResponse>> GetAllAvailableUsersAsync();
        Task<HardwareResponse> GetHardwareByIdAsync(GetHardwareByIdRequest request);
        Task<List<HardwareResponse>> GetAllHardwareByMACDeviceAsync(GetHardwareByMACDeviceRequest request);
    }
}
