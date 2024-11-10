namespace Application.Exceptions;

public class ShiftStatusException : Exception
{
    public ShiftStatusException() : base("Action not allowed by shift status.") { }
    public ShiftStatusException(string message) : base(message) { }
    public ShiftStatusException(string message, Exception innerException) : base(message, innerException) { }
}
