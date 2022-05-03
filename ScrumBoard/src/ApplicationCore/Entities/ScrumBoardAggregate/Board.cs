namespace ApplicationCore.Entities.ScrumBoard.ScrumBoardAggregate;

public class Board
{
    public Board(string name)
    {
        Name = name;
        Columns = new List<Column>();
    }

    public int BoardId { get; private set; }

    public string Name { get; private set; }

    public List<Column> Columns { get; private set; }
}
