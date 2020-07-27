using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MPIS.Device.AplicationService.DTOs.User;
using MPIS.Device.Repository.Abstract;
using MPIS.Device.RepositoryModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPIS.Device.Repository
{
    public class UserRepository : Package.Repository.Repository, IUserRepository
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(Context context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> CreateUserAsync(CreateUserRequest request)
        {
            var id = await AddAsync(_mapper.Map<DomainModel.User>(request));
            await SaveAsync();

            return id;
        }

        public async Task<bool> DeleteUserByIdAsync(DeleteUserRequest request)
        {
            var result = await DeleteAsync<DomainModel.User>(request.Id);
            await SaveAsync();

            return result;
        }

        public async Task<bool> UpdateUserAsync(UpdateUserRequest request)
        {
            var result = await UpdateAsync(_mapper.Map<DomainModel.User>(request));
            await SaveAsync();

            return result;
        }
    }
}
