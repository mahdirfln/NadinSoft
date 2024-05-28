using Microsoft.EntityFrameworkCore;
using NadinSoft.Domain.Entities;
using NadinSoft.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.Interfaces.Repositories
{
    public class UserRepository
    {
        private readonly NadinSoftDbContext _nadinSoftDbContext;

        public UserRepository(NadinSoftDbContext nadinSoftDbContext)
        {
            nadinSoftDbContext = _nadinSoftDbContext;
        }

        public async Task<int> Add(User entity)
        {
            await _nadinSoftDbContext.AddAsync(entity);

            await _nadinSoftDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Delete(User entity)
        {
            _nadinSoftDbContext.Remove(entity);

            await _nadinSoftDbContext.SaveChangesAsync();
        }

        public async Task<User> Edit(User entity)
        {
            _nadinSoftDbContext.Update(entity);

            await _nadinSoftDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IList<User>> GetAll()
        {
            return await _nadinSoftDbContext.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _nadinSoftDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
