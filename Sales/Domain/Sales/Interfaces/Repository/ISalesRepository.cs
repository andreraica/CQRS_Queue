using Domain.Sales.Models;

namespace Domain.Sales.Interfaces.Repository
{
    public interface ISalesRepository
    {
        Sale MakeSale(Sale sale);
    }
}
