using ApplicationCore.Constants;
using Task = ApplicationCore.Entities.ScrumBoard.ScrumBoardAggregate.Task;

namespace ApplicationCore.DTO;

public class TaskDTO
{
    public TaskDTO(Task task)
    {
        TaskId = task.TaskId;
        Name = task.Name;
        Description = task.Description;
        Priority = ((TaskPriority)task.Priority).ToString();
    }

    public int TaskId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Priority { get; set; }
}
