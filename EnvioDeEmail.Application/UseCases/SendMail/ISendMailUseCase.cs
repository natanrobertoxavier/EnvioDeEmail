using EnvioDeEmail.Communication.Request;
using EnvioDeEmail.Communication.Response;

namespace EnvioDeEmail.Application.UseCases.SendMail;
public interface ISendMailUseCase
{
    Task<ResponseSendMailJson> Execute(RequestSendMailJson request);
}
