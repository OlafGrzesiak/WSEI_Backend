namespace ApplicationCore.Exceptions;

public class DuplicateAnswerException : Exception
{
    public DuplicateAnswerException(string? message) : base(message)
    {
        
    }
}