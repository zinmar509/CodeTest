using BookingSystem.DAL.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Repositories.Interface
{
    public interface IEFfRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Root { get; }

        TEntity Create(TEntity entity);
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entityList);
        Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entityList, CancellationToken cancellationToken = default);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression, bool tracking = false);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression, bool tracking = false);
        IPagedList<TEntity> GetPaging(Expression<Func<TEntity, bool>> expression, IPagination pagination);
        TEntity GetSingle(Expression<Func<TEntity, bool>> expression, bool tracking = false);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression, bool tracking = false);
        bool IsExist(Expression<Func<TEntity, bool>> expression);
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression);
        TEntity Remove(TEntity entity);
        IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entityList);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entityList);
    }

}
