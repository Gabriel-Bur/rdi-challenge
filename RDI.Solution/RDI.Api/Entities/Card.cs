using System;

namespace RDI.Api.Entities
{
    public class Card
    {
        public int CardId { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; }
        public Customer CardOwner { get; set; }
        
        internal Card()
        {

        }

        public Card(long cardNumber,
            int cvv,
            Customer cardOwner)
        {
            CardNumber = cardNumber;
            CVV = cvv;
            CardOwner = cardOwner;
        }
    }
}
