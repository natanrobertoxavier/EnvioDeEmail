using AutoMapper;
using EnvioDeEmail.Communication.Request;
using EnvioDeEmail.Communication.Response;
using EnvioDeEmail.Domain.Repository;
using EnvioDeEmail.Exceptions.ExceptionBase;

namespace EnvioDeEmail.Application.UseCases.SendMail;
public class SendMailUseCase : ISendMailUseCase
{
    private readonly IMailOnlySender _mailSenderRepository;
    private readonly IMapper _mapper;

    public SendMailUseCase(
        IMailOnlySender mailSenderRepository,
        IMapper mapper)
    {
        _mailSenderRepository = mailSenderRepository;
        _mapper = mapper;
    }

    public async Task<ResponseSendMailJson> Execute(RequestSendMailJson request)
    {
        await ValidateData(request);

        var entity = _mapper.Map<Domain.Entities.Mail>(request);

        return await _mailSenderRepository.Send(entity);
    }

    private async Task ValidateData(RequestSendMailJson request)
    {
        var validator = new SendMailValidator(request.Recipient);

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var messageError = result.Errors.Select(error => error.ErrorMessage).Distinct().ToList();
            throw new ExceptionValidationErrors(messageError);
        }
    }
}
