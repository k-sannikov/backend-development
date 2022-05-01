namespace ScrumBoard.Exceptions;

public class TaskExistException : Exception
{
    public TaskExistException() : base("Задача существует")
    {
    }
}
