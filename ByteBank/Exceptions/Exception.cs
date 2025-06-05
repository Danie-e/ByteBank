using System.Runtime.Serialization;

namespace ByteBank.Exceptions;

public class ByteBankException : Exception
{
    public ByteBankException() { }
    public ByteBankException(string message) : base("Houve uma exceção ->"+message) { }
    public ByteBankException(string message, Exception inner) : base(message, inner) { }
    protected ByteBankException(
      SerializationInfo info,
      StreamingContext context) : base(info, context) { }
}

