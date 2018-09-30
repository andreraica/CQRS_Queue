using Domain.General.Commands;
using Domain.General.Events;
using Domain.General.Mediator;
using Domain.General.Queue;
using MediatR;
using System.Threading.Tasks;

namespace Infrastructure.IoC.Mediator
{
    public sealed class InMemoryMediator : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;
        private readonly ISender _sender;

        public InMemoryMediator(IEventStore eventStore, IMediator mediator, ISender sender)
        {
            _eventStore = eventStore;
            _mediator = mediator;
            _sender = sender;
        }

        public Task SendCommand<T>(T command) where T : Command =>
            Publish(command);


        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
            {
                _eventStore?.Save(@event);
                _sender.Send(@event);
            }

            return Publish(@event);
        }

        public Task RaiseEvent<T>(T @event, bool saveEventSource = true) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
            {
                if (saveEventSource == true)
                    _eventStore?.Save(@event);
            }

            return Publish(@event);
        }

        public Task RaiseEventBus<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
            {
                _sender.Send(@event);
            }

            return Publish(@event);
        }

        public Task RaiseEventBus<T>(T @event, bool saveEventSource = true) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
            {
                _sender.Send(@event);

                if (saveEventSource == true)
                    _eventStore?.Save(@event);
            }

            return Publish(@event);
        }

        private Task Publish<T>(T message) where T : Message =>
            _mediator.Publish(message);
    }
}
