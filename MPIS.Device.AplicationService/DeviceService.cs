#region "Libraries"

using AutoMapper;
using MPIS.Device.AplicationService.Abstract;
using MPIS.Device.AplicationService.DTOs.Device;
using MPIS.Device.Repository;
using MPIS.Device.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.AplicationService
{
    public class DeviceService : IDeviceService
    {

        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public DeviceService(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateDeviceAsync(CreateDeviceRequest request)
        {
            var id = await _deviceRepository.CreateDeviceAsync(request);
            return id;
        }

        public async  Task<bool> DeleteDeviceByIdAsync(DeleteDeviceByIdRequest request)
        {
            var result = await _deviceRepository.DeleteDeviceByIdAsync(request);
            return result;
        }

        public async  Task<List<DeviceResponse>> GetAllDeviceByEmailUserAsync(GetDeviceByEmailUserRequest request)
        {
            var result = await _deviceRepository.GetAllDeviceByEmailUserAsync(request);
            return result;
        }

        public async  Task<DeviceResponse> GetDeviceByIdAsync(GetDeviceByIdRequest request)
        {
            var result = await _deviceRepository.GetDeviceByIdAsync(request);
            return result;
        }

        public async Task<bool> UpdateDeviceAsync(UpdateDeviceRequest request)
        {
            var result = await _deviceRepository.UpdateDeviceAsync(request);
            return result;
        }
    }
}

