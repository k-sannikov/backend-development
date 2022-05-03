namespace ApplicationCore.Exceptions;

public class BoardNotFoundException : Exception
{
    public BoardNotFoundException() : base("Доска не найдена")
    {
    }
}
