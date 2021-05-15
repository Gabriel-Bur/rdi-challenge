using RDI.Api.Entities.Base;
using System;

namespace RDI.Api.Entities
{
    public class Card : Auditable
    {
        public int CardId { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }

        public Customer CustomerCardOwner { get; set; }
        public int CustomerId { get; set; }
        
        internal Card() {}

        public Card(
            long cardNumber,
            int cvv,
            int customerId)
        {
            CardNumber = cardNumber;
            CVV = cvv;
            setCardOwner(customerId);
        }

        private void setCardOwner(int customerId)
        {
            CustomerCardOwner = new Customer(customerId);
        }
    }
}
