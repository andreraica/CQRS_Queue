using Domain.General.Interfaces;
using Infrastructure.Data.General.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure.Data.General.Repository
{
    public class Repository<TEntity, TID> : IRepository<TEntity, TID> where TEntity : class
    {
        protected readonly DbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(SalesContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj) =>
            DbSet.Add(obj);


        public virtual TEntity GetById(TID id)
        {
            var result = DbSet.Find(id);

            if (result != null)
                Db.Entry(result).Reload();

            return result;
        }

        public virtual IQueryable<TEntity> GetAll() => DbSet;

        public virtual void Update(TEntity obj) =>
            DbSet.Update(obj);

        public virtual void Remove(TID id) =>
            DbSet.Remove(DbSet.Find(id));


        public int SaveChanges() =>
            Db.SaveChanges();

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
