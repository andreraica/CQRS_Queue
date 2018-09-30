using Domain.General.Commands;
using Domain.General.Interfaces;
using Domain.General.Mediator;
using Domain.General.Notifications;
using Domain.Sales.Interfaces.Repository;
using Domain.Sales.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Sales.Commands
{
    public class SalesHandler : CommandHandler,
                                INotificationHandler<MakeSellCommand>
    {
        private readonly ISalesRepository _salesRepository;
        
        public SalesHandler(IUnitOfWork uow,
                            IMediatorHandler mediator,
                            INotificationHandler<DomainNotification> notifications,
                            ISalesRepository salesRepository)
            : base(uow, mediator, notifications)
        {
            _salesRepository = salesRepository;
        }

        public Task Handle(MakeSellCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                NotifyValidationErrors(command);
                return Task.CompletedTask;
            }

            var sale = new Sale(command.Id, command.Quantity);

            Commit();

            return Task.CompletedTask;
        }
    }
}
