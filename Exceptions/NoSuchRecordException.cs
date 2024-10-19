namespace Lab2.Exceptions;

public class NoSuchRecordException : Exception
{
    public NoSuchRecordException() : base() { }
    public NoSuchRecordException(string message) : base(message) { }
    public NoSuchRecordException(string message, Exception inner) : base(message, inner) { }
}
