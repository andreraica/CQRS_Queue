using Domain.General.Events;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data.General.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
