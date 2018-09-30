using Domain.Sales.Interfaces.Repository;
using Domain.Sales.Models;

namespace Infrastructure.Data.Sales.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        public SalesRepository()
        {
        }

        public Sale MakeSale(Sale sale)
        {
            throw new System.NotImplementedException();
        }
    }
}
