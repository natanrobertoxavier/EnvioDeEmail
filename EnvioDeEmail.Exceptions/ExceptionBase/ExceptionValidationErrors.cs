using System.Runtime.Serialization;

namespace ControleDeMateriais.Exceptions.ExceptionBase;
public class ExceptionValidationErrors : EnvioDeEmailException
{
    public List<string> MessagesErrors { get; set; }
    public ExceptionValidationErrors(List<string> messageErrors) : base(string.Empty)
    {
        MessagesErrors = messageErrors;
    }

    protected ExceptionValidationErrors(SerializationInfo info, StreamingContext context) : base(info, context) 
    {
    }
}
