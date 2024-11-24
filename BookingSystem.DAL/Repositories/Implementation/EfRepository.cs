using BookingSystem.DAL.Common.Extensions;
using BookingSystem.DAL.Common.Interface;
using BookingSystem.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Repositories.Implementation
{
    public class EfRepository<TEntity> : IEFfRepository<TEntity>
       where TEntity : class
    {
        protected readonly AppDb _appDbContext;
        private readonly DbSet<TEntity> _dbSet;
        public EfRepository(AppDb appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> Root
            => _dbSet.AsQueryable();
        public virtual TEntity Create(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }
        public virtual async Task<TEntity> CreateAsync(TEntity entity,
            CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }
        public virtual IEnumerable<TEntity> CreateRange(IEnumerable<TEntity> entityList)
        {
            _dbSet.AddRange(entityList);
            return entityList;
        }
        public virtual async Task<IEnumerable<TEntity>> CreateRangeAsync(IEnumerable<TEntity> entityList,
            CancellationToken cancellationToken = default)
        {
            await _dbSet.AddRangeAsync(entityList, cancellationToken);
            return entityList;
        }
        public virtual TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
        public virtual IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entityList)
        {
            _dbSet.UpdateRange(entityList);
            return entityList;
        }

        public virtual TEntity Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            return entity;
        }
        public virtual IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entityList)
        {
            _dbSet.RemoveRange(entityList);
            return entityList;
        }
        public virtual bool IsExist(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Any(expression);
        }
        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }
        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> expression, bool tracking = false)
        {
            if (tracking)
                return _dbSet.FirstOrDefault(expression);

            return _dbSet.AsNoTracking().FirstOrDefault(expression);
        }
        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression, bool tracking = false)
        {
            if (tracking)
                return await _dbSet.FirstOrDefaultAsync(expression);

            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(expression);
        }
        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression, bool tracking = false)
        {
            if (tracking)
                return _dbSet.Where(expression);

            return _dbSet.AsNoTracking().Where(expression);
        }
        public virtual async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression, bool tracking = false)
        {
            if (tracking)
                return await _dbSet.Where(expression).ToListAsync();

            return await _dbSet.AsNoTracking().Where(expression).ToListAsync();
        }
        public virtual IPagedList<TEntity> GetPaging(Expression<Func<TEntity, bool>> expression, IPagination pagination)
        {
            return _dbSet.AsNoTracking()
                .Where(expression).ToPaginate(pagination);
        }
    }
}
