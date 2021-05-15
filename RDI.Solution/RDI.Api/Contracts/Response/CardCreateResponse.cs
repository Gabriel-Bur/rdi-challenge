using System;

namespace RDI.Api.Contracts.Response
{
    public class CardCreateResponse
    {
        public DateTime RegistrationDate { get; set; }
        public long Token { get; set; }
        public int CardId { get; set; }

        /*
         Registration date – Date now in UTC

Token – long – (Size of token may vary)

CardId - int
         
         */
    }
}
