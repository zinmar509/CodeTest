using BookingSystem.Common.Attributes;
using BookingSystem.DAL.Common;
using BookingSystem.DAL.Common.Enum;
using BookingSystem.DAL.Common.Interface;
using BookingSystem.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Repositories.Implementation
{
    [ScopedDependency]
    public class UnitOfWork : IUnitOfWork
    {
        readonly AppDb _appdb;
        readonly ICurrentUserService _currentUserService;
        public UnitOfWork(AppDb appdb, ICurrentUserService currentUserService)
        {
            _appdb = appdb;
            _currentUserService = currentUserService;
        }
        public IEFfRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class
        {
            return new EfRepository<TEntity>(_appdb);
        }
        public void SaveChanges()
        {
            UpdateEntityStates();

            _appdb.SaveChanges();
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateEntityStates();
            await _appdb.SaveChangesAsync(cancellationToken);
        }
        void UpdateEntityStates()
        {
            var entries = _appdb.ChangeTracker.Entries<BookingSystemEntityBase>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.Status = Status.Active.ToString();
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = _currentUserService.CurrentUserId;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedDate = DateTime.Now;
                }
            }
        }

      



    }
}
