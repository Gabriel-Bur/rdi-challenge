using System.Collections.Generic;

namespace RDI.Api.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public List<Card> Cards { get; set; }
    }
}
