using EnvioDeEmail.Application.UseCases.SendMail;
using EnvioDeEmail.Communication.Request;
using EnvioDeEmail.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace EnvioDeEmail.Api.Controllers;

public class EmailController : EnvioDeEmailController
{
    [HttpPost]
    [Route("Send")]
    [ProducesResponseType(typeof(ResponseSendMailJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> SendMail(
        [FromServices] ISendMailUseCase useCase,
        [FromBody] RequestSendMailJson request)
    {
        var response = await useCase.Execute(request);

        return Ok(response);
    }
}
