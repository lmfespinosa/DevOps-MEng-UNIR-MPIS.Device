#region "Libraries"

using AutoMapper;
using MPIS.Device.AplicationService.Abstract;
using MPIS.Device.AplicationService.DTOs.Software;
using MPIS.Device.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.AplicationService
{
    public class SoftwareService : ISoftwareService
    {

        private readonly ISoftwareRepository _softwareRepository;
        private readonly IMapper _mapper;

        public SoftwareService(ISoftwareRepository softwareRepository, IMapper mapper)
        {
            _softwareRepository = softwareRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateSoftwareAsync(CreateSoftwareRequest request)
        {
            var id = await _softwareRepository.CreateSoftwareAsync(request);
            return id;
        }

        public async Task<bool> DeleteSoftwareByIdAsync(DeleteSoftwareByIdRequest request)
        {
            var result = await _softwareRepository.DeleteSoftwareByIdAsync(request);
            return result;
        }

        public async Task<List<SoftwareResponse>> GetAllSoftwareByMACDeviceAsync(GetSoftwareByMACDeviceRequest request)
        {
            var result = await _softwareRepository.GetAllSoftwareByMACDeviceAsync(request);
            return result;
        }

        public async Task<SoftwareResponse> GetSoftwareByIdAsync(GetSoftwareByIdRequest request)
        {
            var result = await _softwareRepository.GetSoftwareByIdAsync(request);
            return result;
        }

        public async Task<bool> UpdateSoftwareAsync(UpdateSoftwareRequest request)
        {
            var result = await _softwareRepository.UpdateSoftwareAsync(request);
            return result;
        }
    }
}
