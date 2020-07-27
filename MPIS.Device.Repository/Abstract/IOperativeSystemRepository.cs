#region "Libraries"

using MPIS.Device.AplicationService.DTOs.OperativeSystem;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Repository.Abstract
{
    public interface IOperativeSystemRepository
    {
        Task<Guid> CreateOperativeSystemAsync(CreateOperativeSystemRequest request);
        Task<bool> UpdateOperativeSystemAsync(UpdateOperativeSystemRequest request);
        Task<bool> DeleteOperativeSystemByIdAsync(DeleteOperativeSystemByIdRequest request);
        //Task<List<DevicesResponse>> GetAllAvailableUsersAsync();
        Task<OperativeSystemResponse> GetOperativeSystemByIdAsync(GetOperativeSystemByIdRequest request);
        Task<List<OperativeSystemResponse>> GetAllOperativeSystemByMACDeviceAsync(GetOperativeSystemByMACDeviceRequest request);
    }
}
