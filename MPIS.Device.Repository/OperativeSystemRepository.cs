#region "Libraries"

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MPIS.Device.AplicationService.DTOs.OperativeSystem;
using MPIS.Device.Repository.Abstract;
using MPIS.Device.RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Repository
{
    public class OperativeSystemRepository : Package.Repository.Repository, IOperativeSystemRepository
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public OperativeSystemRepository(Context context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateOperativeSystemAsync(CreateOperativeSystemRequest request)
        {
            var id = await AddAsync(_mapper.Map<DomainModel.OperativeSystem>(request));
            await SaveAsync();

            return id;
        }

        public async Task<bool> DeleteOperativeSystemByIdAsync(DeleteOperativeSystemByIdRequest request)
        {
            var result = await DeleteAsync<DomainModel.OperativeSystem>(request.Id);
            await SaveAsync();

            return result;
        }

        public async Task<List<OperativeSystemResponse>> GetAllOperativeSystemByMACDeviceAsync(GetOperativeSystemByMACDeviceRequest request)
        {
            return await GetAsync<DomainModel.OperativeSystem>()
                .Where(x => !x.Deleted.HasValue && x.IsActive() && x.MACDevice == request.MACDevice)
                .ProjectTo<OperativeSystemResponse>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<OperativeSystemResponse> GetOperativeSystemByIdAsync(GetOperativeSystemByIdRequest request)
        {
            return await GetAsync<DomainModel.OperativeSystem>()
               .Where(x => x.Id == request.Id)
               .ProjectTo<OperativeSystemResponse>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateOperativeSystemAsync(UpdateOperativeSystemRequest request)
        {
            var result = await UpdateAsync(_mapper.Map<DomainModel.OperativeSystem>(request));
            await SaveAsync();

            return result;
        }
    }
}
