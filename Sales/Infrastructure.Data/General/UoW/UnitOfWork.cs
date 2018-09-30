using Domain.General.Commands;
using Domain.General.Interfaces;
using Infrastructure.Data.General.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Data.General.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SalesContext _context;

        public UnitOfWork(SalesContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            int rowsAffected = 0;
            try
            {
                rowsAffected = _context.SaveChanges(false);
                _context.ChangeTracker.AcceptAllChanges();
            }
            catch (System.Exception ex)
            {
                //if a added item throw a error, this entry need be removed
                System.Collections.Generic.List<Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry> entries = _context.ChangeTracker.Entries()
                  .Where(e => e != null && e.State == EntityState.Added)
                      .ToList();

                foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry item in entries)
                {
                    item.State = EntityState.Detached;
                }

                //or if entrie was modified or deleted, need be reloaded
                entries = _context.ChangeTracker.Entries()
               .Where(e => e.State == EntityState.Modified || e.State == EntityState.Deleted)
                   .ToList();


                foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry item in entries)
                {
                    item.Reload();
                }
                throw ex;
            }

            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
