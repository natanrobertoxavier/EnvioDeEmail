using EnvioDeEmail.Communication.Response;

namespace EnvioDeEmail.Domain.Repository;
public interface IMailOnlySender
{
    Task<ResponseSendMailJson> Send(Entities.Mail mail);
}
