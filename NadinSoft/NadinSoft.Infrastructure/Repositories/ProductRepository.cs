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
    public class ProductRepository
    {
        private readonly NadinSoftDbContext _nadinSoftDbContext;

        public ProductRepository(NadinSoftDbContext nadinSoftDbContext)
        {
            nadinSoftDbContext = _nadinSoftDbContext;
        }

        public async Task<int> Add(Product entity)
        {
            await _nadinSoftDbContext.AddAsync(entity);

            await _nadinSoftDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Delete(Product entity)
        {
            _nadinSoftDbContext.Remove(entity);

            await _nadinSoftDbContext.SaveChangesAsync();
        }

        public async Task<Product> Edit(Product entity)
        {
            _nadinSoftDbContext.Update(entity);

            await _nadinSoftDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IList<Product>> GetAll()
        {
            return await _nadinSoftDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _nadinSoftDbContext.Products.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
