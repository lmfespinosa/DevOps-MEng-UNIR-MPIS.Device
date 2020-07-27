#region "Libraries"

using AutoMapper;
using MPIS.Device.AplicationService.Abstract;
using MPIS.Device.AplicationService.DTOs.OperativeSystem;
using MPIS.Device.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.AplicationService
{
    public class OperativeSystemService : IOperativeSystemService
    {
        private readonly IOperativeSystemRepository _operativeSystemRepository;
        private readonly IMapper _mapper;

        public OperativeSystemService(IOperativeSystemRepository operativeSystemRepository, IMapper mapper)
        {
            _operativeSystemRepository = operativeSystemRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateOperativeSystemAsync(CreateOperativeSystemRequest request)
        {
            var id = await _operativeSystemRepository.CreateOperativeSystemAsync(request);
            return id;
        }

        public async Task<bool> DeleteOperativeSystemByIdAsync(DeleteOperativeSystemByIdRequest request)
        {
            var result = await _operativeSystemRepository.DeleteOperativeSystemByIdAsync(request);
            return result;
        }

        public async Task<List<OperativeSystemResponse>> GetAllOperativeSystemByMACDeviceAsync(GetOperativeSystemByMACDeviceRequest request)
        {
            var result = await _operativeSystemRepository.GetAllOperativeSystemByMACDeviceAsync(request);
            return result;
        }

        public async Task<OperativeSystemResponse> GetOperativeSystemByIdAsync(GetOperativeSystemByIdRequest request)
        {
            var result = await _operativeSystemRepository.GetOperativeSystemByIdAsync(request);
            return result;
        }

        public async Task<bool> UpdateOperativeSystemAsync(UpdateOperativeSystemRequest request)
        {
            var result = await _operativeSystemRepository.UpdateOperativeSystemAsync(request);
            return result;
        }
    }
}
