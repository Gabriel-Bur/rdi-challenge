using Microsoft.AspNetCore.Mvc;
using RDI.Api.Contracts.Request;
using RDI.Api.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RDI.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] CardCreateCommand value)
        {
            try
            {
                var response = await _cardService.CreateCustomerCard(value);
                if (response == null)
                    return BadRequest("Card number already exists for this customer");

                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return Problem("Something went wrong, please try again later", statusCode: (int)HttpStatusCode.InternalServerError);
        }
    }
}
