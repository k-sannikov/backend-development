namespace ApplicationCore.Exceptions;

public class UndefinedPriorityException : System.Exception
{
    public UndefinedPriorityException() : base("Неопределенный приоритет")
    {
    }
}