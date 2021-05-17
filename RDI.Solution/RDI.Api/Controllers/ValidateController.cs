using Microsoft.AspNetCore.Mvc;
using RDI.Api.Contracts.Request;
using RDI.Api.Services.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace RDI.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValidateController : ControllerBase
    {
        private readonly IValidateService _validateService;
        public ValidateController(IValidateService validateService)
        {
            _validateService = validateService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] ValidateCommand value)
        {
            try
            {
                var response = await _validateService.ValidateCard(value);
                if (response)
                    return Ok(response);

                return BadRequest("Invalid");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return Problem("Something went wrong, please try again later", statusCode: (int)HttpStatusCode.InternalServerError);
        }
    }
}
