using RDI.Api.Contracts.Request;
using RDI.Api.Contracts.Response;
using System.Threading.Tasks;

namespace RDI.Api.Interfaces
{
    public interface ICardService
    {
        Task<CardCreateResponse> CreateCustomerCard(CardCreateCommand cardCreateCommand);
    }
}
