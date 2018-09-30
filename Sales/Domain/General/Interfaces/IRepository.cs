using System;
using System.Linq;

namespace Domain.General.Interfaces
{
    public interface IRepository<TEntity, TID> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(TID id);

        IQueryable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TID id);

        int SaveChanges();
    }
}
