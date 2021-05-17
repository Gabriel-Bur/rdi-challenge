using RDI.Api.Contracts.Request;
using System.Threading.Tasks;

namespace RDI.Api.Services.Interfaces
{
    public interface IValidateService
    {
        Task<bool> ValidateCard(ValidateCommand  validateCommand);
    }
}
