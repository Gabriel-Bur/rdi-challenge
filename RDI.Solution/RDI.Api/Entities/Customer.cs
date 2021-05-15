using System.Collections.Generic;

namespace RDI.Api.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public readonly List<Card> Cards;

        internal Customer(int customerId)
        {
            CustomerId = customerId;
        }
    }
}
