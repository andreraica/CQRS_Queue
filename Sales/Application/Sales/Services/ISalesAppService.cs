using Domain.Sales.Models;

namespace Application.Sales.Services
{
    public interface ISalesAppService
    {
        void MakeSale(Sale sale);
    }
}
