namespace ScrumBoard.Exceptions;

public class ColumnNotFoundException : Exception
{
    public ColumnNotFoundException() : base("Колонка не найдена")
    {
    }
}
