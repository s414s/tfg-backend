using System.Runtime.Serialization;

namespace Domain.Exceptions;

[Serializable]
public class CustomException : Exception
{
    // Default constructor.
    public CustomException() { }

    public CustomException(string message)
        : base(message) { }

    public CustomException(string message, Exception innerException)
        : base(message, innerException) { }

    // The protected constructor is needed for deserialization.
    protected CustomException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
