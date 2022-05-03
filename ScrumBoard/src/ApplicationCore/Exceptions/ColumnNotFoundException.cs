namespace ApplicationCore.Exceptions;

public class ColumnNotFoundException : Exception
{
    public ColumnNotFoundException() : base("Колонка не найдена")
    {
    }
}
