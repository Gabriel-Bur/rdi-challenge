using System.Collections.Generic;

namespace RDI.Api.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public Card Card { get; set; }

        internal Customer(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
