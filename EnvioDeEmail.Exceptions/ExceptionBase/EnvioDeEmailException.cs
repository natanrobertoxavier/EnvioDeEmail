using System.Runtime.Serialization;

namespace EnvioDeEmail.Exceptions.ExceptionBase;
public class EnvioDeEmailException : SystemException
{
    public EnvioDeEmailException(string message) : base(message)
    {
    }

    public EnvioDeEmailException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
