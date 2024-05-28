using NadinSoft.Domain.Entities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinSoft.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> Table();

        Task<TEntity> GetById(int id);

        Task<IList<TEntity>> GetAll();

        Task<int> Add(TEntity entity);

        Task<TEntity> Edit(TEntity entity);

        Task Delete(TEntity entity);
    }
}
