using ApplicationCore.DTO;
using ApplicationCore.Entities.ScrumBoard.ScrumBoardAggregate;
using Task = ApplicationCore.Entities.ScrumBoard.ScrumBoardAggregate.Task;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ApplicationCore.Exceptions;
using ApplicationCore.Constants;

namespace Infrastructure.Data;

public class ScrumBoardRepository : IScrumBoardRepository
{
    private readonly ScrumBoardContext _db;

    public ScrumBoardRepository(IConfiguration configuration)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ScrumBoardContext>();

        DbContextOptions<ScrumBoardContext>? options = optionsBuilder.UseMySql(
                configuration.GetConnectionString("Default"),
                ServerVersion.AutoDetect(configuration.GetConnectionString("Default"))
            ).Options;

        _db = new ScrumBoardContext(options);
    }


    public IEnumerable<BoardDTO> GetListBoard()
    {
        return _db.Boards.Include(c => c.Columns)
            .ThenInclude(t => t.Tasks)
            .Select(board => new BoardDTO(board));
    }

    public BoardDTO GetBoard(int boardId)
    {
        Board? board = _db.Boards.Include(c => c.Columns)
            .ThenInclude(t => t.Tasks)
            .Where(b => b.BoardId == boardId)
            .FirstOrDefault();

        if (board == null)
        {
            throw new BoardNotFoundException();
        }

        return new BoardDTO(board);
    }

    public void CreateBoard(CreateBoardDTO param)
    {
        Board board = new(param.Name);

        _db.Boards.Add(board);
        _db.SaveChanges();
    }

    public void DeleteBoard(int boardId)
    {
        Board? board = _db.Boards.Find(boardId);
        if (board != null)
        {
            _db.Boards.Remove(board);
            _db.SaveChanges();
        }
        else
        {
            throw new BoardNotFoundException();
        }
    }

    public void CreateColumn(int boardId, CreateColumnDTO param)
    {
        Board? board = _db.Boards.Include(c => c.Columns)
            .Where(b => b.BoardId == boardId)
            .FirstOrDefault();

        if (board != null)
        {
            if (board.Columns.Count() < limitationsConstants.COL_MAX)
            {
                Column column = new(param.Name, boardId);

                _db.Columns.Add(column);
                _db.SaveChanges();
            }
            else
            {
                throw new ColumnsOverflowLimitException();
            }
        }
        else
        {
            throw new BoardNotFoundException();
        }
    }

    public void EditColumn(int columnId, EditColumnDTO param)
    {
        Column? column = _db.Columns.Find(columnId);
        if (column != null)
        {
            column.Name = param.Name;
            _db.SaveChanges();
        }
        else
        {
            throw new ColumnNotFoundException();
        }
    }

    public void DeleteColumn(int columnId)
    {
        Column? column = _db.Columns.Find(columnId);
        if (column != null)
        {
            _db.Columns.Remove(column);
            _db.SaveChanges();
        }
        else
        {
            throw new ColumnNotFoundException();
        }
    }


    public void CreateTask(int boardId, CreateTaskDTO param)
    {
        if ((param.Priority < (int)TaskPriority.Low) || (param.Priority > (int)TaskPriority.High))
        {
            throw new UndefinedPriorityException();
        }

        Board? board = _db.Boards.Include(c => c.Columns)
            .Where(b => b.BoardId == boardId)
            .FirstOrDefault();

        if (board != null)
        {
            Column? column = board.Columns.FirstOrDefault();
            if (column != null)
            {
                Task task = new(param.Name, param.Description, param.Priority, column.ColumnId);

                _db.Tasks.Add(task);
                _db.SaveChanges();
            }
            else
            {
                throw new ColumnNotFoundException();
            }
        }
        else
        {
            throw new BoardNotFoundException();
        }
    }

    public void EditTask(int taskId, EditTaskDTO param)
    {
        if ((param.Priority < (int)TaskPriority.Low) || (param.Priority > (int)TaskPriority.High))
        {
            throw new UndefinedPriorityException();
        }

        Task? task = _db.Tasks.Find(taskId);
        if (task != null)
        {
            task.Name = param.Name;
            task.Description = param.Description;
            task.Priority = param.Priority;
            _db.SaveChanges();
        }
        else
        {
            throw new TaskNotFoundException();
        }
    }

    public void DeleteTask(int taskId)
    {
        Task? task = _db.Tasks.Find(taskId);
        if (task != null)
        {
            _db.Tasks.Remove(task);
            _db.SaveChanges();
        }
        else
        {
            throw new TaskNotFoundException();
        }
    }

    public void TransferTask(int taskId, int columnId)
    {
        Task? task = _db.Tasks.Find(taskId);

        if (task == null)
        {
            throw new TaskNotFoundException();
        }

        Column? column = _db.Columns.Find(columnId);

        if (column == null)
        {
            throw new ColumnNotFoundException();
        }

        task.ColumnId = columnId;
        _db.SaveChanges();
    }
}