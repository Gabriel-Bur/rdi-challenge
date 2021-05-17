using Microsoft.EntityFrameworkCore;
using RDI.Api.Context;
using RDI.Api.Contracts.Request;
using RDI.Api.Contracts.Response;
using RDI.Api.Entities;
using RDI.Api.Interfaces;
using System.Threading.Tasks;

namespace RDI.Api.Services
{
    public class CardService : ICardService
    {
        private readonly RDIContextDb _db;
        public CardService(RDIContextDb db)
        {
            _db = db;
        }

        public async Task<CardCreateResponse> CreateCustomerCard(CardCreateCommand cardCreateCommand)
        {
            //check if card already exist for specified customerid
            if (await CardExist(cardCreateCommand.CardNumber, cardCreateCommand.CustomerId))
                return null;

            Card newCard = new(cardCreateCommand.CardNumber, cardCreateCommand.CVV, cardCreateCommand.CustomerId);

            await _db.Cards.AddAsync(newCard);
            await _db.SaveChangesAsync();

            return new CardCreateResponse()
            {
                CardId = newCard.CardId,
                RegistrationDate = newCard.Created,
                Token = Token.TokenGenerator.Instance.GenerateToken(newCard.CardNumber, newCard.CVV),
            };
        }

        private async Task<bool> CardExist(long cardNumber, int customerId)
        {
            var card = await _db.Cards
                .FirstOrDefaultAsync(c => c.CardNumber.Equals(cardNumber) && c.CustomerId.Equals(customerId));
            return card != null;
        }
    }
}
