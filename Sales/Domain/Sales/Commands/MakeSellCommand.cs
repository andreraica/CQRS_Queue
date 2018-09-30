using Domain.General.Commands;
using System;

namespace Domain.Sales.Commands
{
    public class MakeSellCommand : Command
    {
        public MakeSellCommand(int id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public int Id { get; private set; }
        public int Quantity { get; private set; }

        public override bool IsValid()
        {
            return true;
            //throw new NotImplementedException();
        }
    }
}
