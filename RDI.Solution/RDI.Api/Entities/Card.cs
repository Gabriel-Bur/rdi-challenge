using RDI.Api.Entities.Base;

namespace RDI.Api.Entities
{
    public class Card : Auditable
    {
        public int CardId { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        
        protected Card() { }

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
            Customer = new Customer(customerId);
        }
    }
}
