using Domain.General.Commands;
using System;

namespace Domain.General.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
