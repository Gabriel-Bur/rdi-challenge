using RDI.Api.Context;
using RDI.Api.Contracts.Request;
using RDI.Api.Services.Interfaces;
using RDI.Api.Token;
using System;
using System.Threading.Tasks;

namespace RDI.Api.Services
{
    public class ValidateService : IValidateService
    {
        private readonly RDIContextDb _db;
        public ValidateService(RDIContextDb db)
        {
            _db = db;
        }

        public async Task<bool> ValidateCard(ValidateCommand validateCommand)
        {
            var card = await _db.Cards.FindAsync(validateCommand.CardId);
            Console.Write(card.CardNumber);

            if (validateCommand.CustomerId != card.CustomerId)
                return false;

            if ((DateTime.UtcNow - card.Created).TotalMinutes > 30)
                return false;

            var tokenToValidate = TokenGenerator.Instance.GenerateToken(card.CardNumber, card.CVV);
            if (tokenToValidate != validateCommand.Token)
                return false;

            return true;
        }
    }
}
