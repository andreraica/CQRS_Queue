using Domain.General.Mediator;
using Domain.Sales.Commands;
using Domain.Sales.Interfaces.Repository;
using Domain.Sales.Models;

namespace Application.Sales.Services
{
    public class SalesAppService : ISalesAppService
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IMediatorHandler _mediator;

        public SalesAppService(ISalesRepository salesRepository,
            IMediatorHandler mediator)
        {
            _mediator = mediator;
            _salesRepository = salesRepository;
        }

        public void MakeSale(Sale sale)
        {
            var makeSellCommand = new MakeSellCommand(sale.Id, sale.Quantity);

            _mediator.SendCommand(makeSellCommand);
        }
    }
}
