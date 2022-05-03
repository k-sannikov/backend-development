namespace ApplicationCore.Entities.ScrumBoard.ScrumBoardAggregate;

public class Column
{
    public Column(string name, int boardId)
    {
        Name = name;
        BoardId = boardId;
        Tasks = new List<Task>();
    }

    public int ColumnId { get; private set; }

    public string Name { get; set; }
    
    public int BoardId { get; private set; }

    public List<Task> Tasks { get; private set; }

    public Board Board { get; private set; }
}
