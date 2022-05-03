namespace ApplicationCore.Exceptions;

public class ColumnsOverflowLimitException : Exception
{
    public ColumnsOverflowLimitException() : base("Превышение лимита колонок")
    {
    }
}
