#region "Libraries"

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MPIS.Device.AplicationService.DTOs.Software;
using MPIS.Device.Repository.Abstract;
using MPIS.Device.RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Repository
{
    public class SoftwareRepository : Package.Repository.Repository, ISoftwareRepository
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public SoftwareRepository(Context context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateSoftwareAsync(CreateSoftwareRequest request)
        {
            var id = await AddAsync(_mapper.Map<DomainModel.Software>(request));
            await SaveAsync();

            return id;
        }

        public async Task<bool> DeleteSoftwareByIdAsync(DeleteSoftwareByIdRequest request)
        {
            var result = await DeleteAsync<DomainModel.Software>(request.Id);
            await SaveAsync();

            return result;
        }

        public async Task<List<SoftwareResponse>> GetAllSoftwareByMACDeviceAsync(GetSoftwareByMACDeviceRequest request)
        {
            return await GetAsync<DomainModel.Software>()
                .Where(x => !x.Deleted.HasValue && x.IsActive() && x.MACDevice == request.MACDevice)
                .ProjectTo<SoftwareResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<SoftwareResponse> GetSoftwareByIdAsync(GetSoftwareByIdRequest request)
        {
            return await GetAsync<DomainModel.Software>()
               .Where(x => x.Id == request.Id)
               .ProjectTo<SoftwareResponse>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateSoftwareAsync(UpdateSoftwareRequest request)
        {
            var result = await UpdateAsync(_mapper.Map<DomainModel.Software>(request));
            await SaveAsync();

            return result;
        }
    }
}
