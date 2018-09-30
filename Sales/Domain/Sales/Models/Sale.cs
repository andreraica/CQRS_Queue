using System;

namespace Domain.Sales.Models
{
    public class Sale
    {
        public Sale(int id, int quantity)
        {
            Id = id;
            Quantity = quantity;
            Date = DateTime.Now;
        }

        public int Id { get; private set; }
        public int Quantity { get; private set; }
        public DateTime Date { get; private set; }
    }
}
