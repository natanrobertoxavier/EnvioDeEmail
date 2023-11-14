using EnvioDeEmail.Communication.Request;
using EnvioDeEmail.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace EnvioDeEmail.Api.Controllers;

public class EmailController : EnvioDeEmailController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseSendMailJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> Send(
        [FromBody] RequestSendMailJson request)
    {
        var response = new ResponseSendMailJson();

        return Ok(response);
    }
}
