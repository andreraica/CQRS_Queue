using Domain.General.Queue;
using MediatR;
using System;

namespace Domain.General.Events
{
    [Serializable]
    public abstract class Message : MessageQueue, INotification
    {
        //public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
        //public Guid SagaId { get; protected set; }

        protected Message() =>
            MessageType = GetType().Name;

    }
}
