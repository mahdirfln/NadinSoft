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
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly NadinSoftDbContext _nadinSoftDbContext;

        public Repository(NadinSoftDbContext nadinSoftDbContext)
        {
            _nadinSoftDbContext = nadinSoftDbContext;
        }

        public virtual IQueryable<TEntity> Table() => _nadinSoftDbContext.Set<TEntity>();

        public async Task<int> Add(TEntity entity)
        {
            await _nadinSoftDbContext.AddAsync(entity);

            await _nadinSoftDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Delete(TEntity entity)
        {
            _nadinSoftDbContext.Remove(entity);

            await _nadinSoftDbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Edit(TEntity entity)
        {
            _nadinSoftDbContext.Update(entity);

            await _nadinSoftDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await Table().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Table().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
