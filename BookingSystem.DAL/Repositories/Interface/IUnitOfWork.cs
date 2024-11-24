using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.DAL.Repositories.Interface
{
    public interface IUnitOfWork
    {
        IEFfRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        void SaveChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
