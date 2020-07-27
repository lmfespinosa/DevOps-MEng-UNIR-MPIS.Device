#region "Libraries"

using MPIS.Device.AplicationService.DTOs.Software;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.AplicationService.Abstract
{
    public interface ISoftwareService
    {
        Task<Guid> CreateSoftwareAsync(CreateSoftwareRequest request);
        Task<bool> UpdateSoftwareAsync(UpdateSoftwareRequest request);
        Task<bool> DeleteSoftwareByIdAsync(DeleteSoftwareByIdRequest request);
        //Task<List<DevicesResponse>> GetAllAvailableUsersAsync();
        Task<SoftwareResponse> GetSoftwareByIdAsync(GetSoftwareByIdRequest request);
        Task<List<SoftwareResponse>> GetAllSoftwareByMACDeviceAsync(GetSoftwareByMACDeviceRequest request);
    }
}
