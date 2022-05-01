namespace ScrumBoard.Exceptions;

public class TaskNotFoundException : Exception
{
    public TaskNotFoundException() : base("Задача не найдена")
    {
    }
}
