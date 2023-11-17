using EnvioDeEmail.Communication.Response;
using EnvioDeEmail.Domain.Entities;
using EnvioDeEmail.Domain.Repository;
using System.Net;
using System.Net.Mail;

namespace EnvioDeEmail.Infrastructure.AccessRepository.Repository;
public class MailSender : IMailOnlySender
{
    private static string SmtpAdress => Environment.GetEnvironmentVariable("smtp");
    private static int PortNumber =>  int.Parse(Environment.GetEnvironmentVariable("port"));
    private static string EmailFromAdress => Environment.GetEnvironmentVariable("from");
    private static string Password => Environment.GetEnvironmentVariable("key");

    public async Task<ResponseSendMailJson> Send(Mail mail)
    {
        using MailMessage mailMessage = new();

        mailMessage.From = new MailAddress(EmailFromAdress);
        mailMessage.Subject = mail.Subject;
        mailMessage.Body = mail.Body;
        mailMessage.IsBodyHtml = mail.IsHtml;
        mailMessage.Priority = MailPriority.Normal;

        //mailMessage.

        AddEmailsToMailMessage(mailMessage, mail);

        using SmtpClient smtp = new(SmtpAdress, PortNumber);

        smtp.EnableSsl = true;
        smtp.Credentials = new NetworkCredential(EmailFromAdress, Password);

        smtp.UseDefaultCredentials = true;
        smtp.Send(mailMessage);

        return new ResponseSendMailJson
        {
            DateSend = DateTime.Now,
        };
    }

    private static void AddEmailsToMailMessage(MailMessage mailMessage, Mail mail)
    {
        foreach (var email in mail.Recipient)
        {
            mailMessage.To.Add(email);
        }

        if (mail.Copy.Count > 0)
        {
            foreach (var email in mail.Copy)
            {
                mailMessage.CC.Add(email);
            }
        }

        if (mail.HiddenCopy.Count > 0)
        {
            foreach (var email in mail.HiddenCopy)
            {
                mailMessage.Bcc.Add(email);
            }
        }
    }
}
