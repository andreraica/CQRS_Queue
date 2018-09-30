using Domain.General.Commands;
using Domain.General.Events;
using System.Threading.Tasks;

namespace Domain.General.Mediator
{
    public interface IMediatorHandler
    {
        Task RaiseEvent<T>(T @event) where T : Event;
        Task RaiseEvent<T>(T @event, bool saveEventSource) where T : Event;
        Task RaiseEventBus<T>(T @event) where T : Event;
        Task SendCommand<T>(T command) where T : Command;
    }
}
