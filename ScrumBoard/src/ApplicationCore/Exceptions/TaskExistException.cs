namespace ScrumBoard.Exceptions;

public class ColumnExistException : Exception
{
    public ColumnExistException() : base("Колонка существует")
    {
    }
}
