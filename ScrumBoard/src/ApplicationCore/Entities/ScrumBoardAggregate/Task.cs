namespace ApplicationCore.Entities.ScrumBoard.ScrumBoardAggregate;

public class Task
{
    public Task(string name, string description, int priority, int columnId)
    {
        Name = name;
        Description = description;
        Priority = priority;
        ColumnId = columnId;
    }

    public int TaskId { get; private set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int Priority { get; set; }

    public int ColumnId { get; set; }

    public Column Column { get; private set; }
}
