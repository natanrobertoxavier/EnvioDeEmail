namespace EnvioDeEmail.Communication.Request;
public class RequestSendMailJson
{
    public string Sender { get; set; }
    public List<string> Recipient { get; set; }
    public List<string> Copy { get; set; }
    public List<string> HiddenCopy { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public bool IsHtml { get; set; }
}
