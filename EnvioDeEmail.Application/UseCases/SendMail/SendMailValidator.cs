using EnvioDeEmail.Exceptions.ExceptionBase;
using EnvioDeEmail.Communication.Request;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EnvioDeEmail.Application.UseCases.SendMail;
public class SendMailValidator : AbstractValidator<RequestSendMailJson>
{
    public SendMailValidator(List<string> recipient)
    {
        ValidateEmail(recipient);
        RuleFor(c => c.Subject).NotEmpty().WithMessage(ErrorMessagesResource.ASSUNTO_EM_BRANCO);
        RuleFor(c => c.Body).NotEmpty().WithMessage(ErrorMessagesResource.CORPO_EMAIL_EM_BRANCO);
    }

    private void ValidateEmail(List<string> recipient)
    {
        foreach (var recipientItem in recipient)
        {
            RuleFor(c => recipientItem).NotEmpty().WithMessage(ErrorMessagesResource.EMAIL_DESTINATARIO_EM_BRANCO);
            When(c => !string.IsNullOrEmpty(recipientItem), () =>
            {
                RuleFor(c => recipientItem).EmailAddress().WithMessage(ErrorMessagesResource.EMAIL_DESTINATARIO_INVALIDO);
            });



            When(c => !string.IsNullOrEmpty(recipientItem), () =>
            {
                RuleFor(c => recipientItem).Custom((email, context) =>
                {
                    string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
                    var isMatch = Regex.IsMatch(email, pattern);

                    if (!isMatch)
                    {
                        context.AddFailure(new FluentValidation.Results
                            .ValidationFailure(nameof(email), ErrorMessagesResource.EMAIL_DESTINATARIO_INVALIDO));
                    }
                });
            });
        }
    }
}
