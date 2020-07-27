#region "Libraries"

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MPIS.Device.AplicationService.DTOs.Device;
using MPIS.Device.Repository.Abstract;
using MPIS.Device.RepositoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#endregion

namespace MPIS.Device.Repository
{
    public class DeviceRepository : Package.Repository.Repository, IDeviceRepository
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public DeviceRepository(Context context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateDeviceAsync(CreateDeviceRequest request)
        {
            var id = await AddAsync(_mapper.Map<DomainModel.Device>(request));
            await SaveAsync();

            return id;
        }

        public async  Task<bool> DeleteDeviceByIdAsync(DeleteDeviceByIdRequest request)
        {
            var result = await DeleteAsync<DomainModel.Device>(request.Id);
            await SaveAsync();

            return result;
        }

        public async Task<List<DeviceResponse>> GetAllDeviceByEmailUserAsync(GetDeviceByEmailUserRequest request)
        {
            return await GetAsync<DomainModel.Device>()
               .Where(x => !x.Deleted.HasValue && x.IsActive() && x.EmailUser == request.EmailUser)
               .ProjectTo<DeviceResponse>(_mapper.ConfigurationProvider)
               .ToListAsync();
        }

        public async  Task<DeviceResponse> GetDeviceByIdAsync(GetDeviceByIdRequest request)
        {
            return await GetAsync<DomainModel.Device>()
               .Where(x => x.Id == request.Id)
               .ProjectTo<DeviceResponse>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateDeviceAsync(UpdateDeviceRequest request)
        {
            var result = await UpdateAsync(_mapper.Map<DomainModel.Device>(request));
            await SaveAsync();

            return result;
        }
    }
}
