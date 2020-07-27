#region "Libraries"

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MPIS.Device.AplicationService.DTOs.Hardware;
using MPIS.Device.Repository.Abstract;
using MPIS.Device.RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Repository
{
    public class HardwareRepository : Package.Repository.Repository, IHardwareRepository
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public HardwareRepository(Context context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateHardwareAsync(CreateHardwareRequest request)
        {
            var id = await AddAsync(_mapper.Map<DomainModel.Hardware>(request));
            await SaveAsync();

            return id;
        }

        public async Task<bool> DeleteHardwareByIdAsync(DeleteHardwareByIdRequest request)
        {
            var result = await DeleteAsync<DomainModel.Hardware>(request.Id);
            await SaveAsync();

            return result;
        }

        public async Task<List<HardwareResponse>> GetAllHardwareByMACDeviceAsync(GetHardwareByMACDeviceRequest request)
        {
            return await GetAsync<DomainModel.Hardware>()
                .Where(x => !x.Deleted.HasValue && x.IsActive() && x.MACDevice == request.MACDevice)
                .ProjectTo<HardwareResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<HardwareResponse> GetHardwareByIdAsync(GetHardwareByIdRequest request)
        {
            return await GetAsync<DomainModel.Hardware>()
               .Where(x => x.Id == request.Id)
               .ProjectTo<HardwareResponse>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateHardwareAsync(UpdateHardwareRequest request)
        {
            var result = await UpdateAsync(_mapper.Map<DomainModel.Hardware>(request));
            await SaveAsync();

            return result;
        }
    }
}
