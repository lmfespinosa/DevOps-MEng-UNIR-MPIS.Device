#region "Libraries"

using AutoMapper;
using MPIS.Device.AplicationService.Abstract;
using MPIS.Device.AplicationService.DTOs.Hardware;
using MPIS.Device.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.AplicationService
{
    public class HardwareService : IHardwareService
    {

        private readonly IHardwareRepository _hardwareRepository;
        private readonly IMapper _mapper;

        public HardwareService(IHardwareRepository hardwareRepository, IMapper mapper)
        {
            _hardwareRepository = hardwareRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateHardwareAsync(CreateHardwareRequest request)
        {
            var id = await _hardwareRepository.CreateHardwareAsync(request);
            return id;
        }

        public async Task<bool> DeleteHardwareByIdAsync(DeleteHardwareByIdRequest request)
        {
            var result = await _hardwareRepository.DeleteHardwareByIdAsync(request);
            return result;
        }

        public async Task<List<HardwareResponse>> GetAllHardwareByMACDeviceAsync(GetHardwareByMACDeviceRequest request)
        {
            var result = await _hardwareRepository.GetAllHardwareByMACDeviceAsync(request);
            return result;
        }

        public async Task<HardwareResponse> GetHardwareByIdAsync(GetHardwareByIdRequest request)
        {
            var result = await _hardwareRepository.GetHardwareByIdAsync(request);
            return result;
        }

        public async Task<bool> UpdateHardwareAsync(UpdateHardwareRequest request)
        {
            var result = await _hardwareRepository.UpdateHardwareAsync(request);
            return result;
        }
    }
}
