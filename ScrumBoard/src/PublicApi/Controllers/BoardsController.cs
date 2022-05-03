using ApplicationCore.DTO;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ScrumBoardAPI.Controllers;

[Route("api/boards")]
[ApiController]
public class BoardsController : ControllerBase
{
    private readonly IScrumBoardRepository _repository;

    public BoardsController(IScrumBoardRepository repository)
    {
        _repository = repository;
    }

    // Получить список досок
    // GET: api/boards
    [HttpGet]
    public IActionResult GetListBoards()
    {
        return Ok(_repository.GetListBoard());
    }

    // Получить доску
    // GET api/boards/{boardId}
    [HttpGet("{boardId}")]
    public IActionResult GetBoardByGUID(int boardId)
    {
        BoardDTO board;
        try
        {
            board = _repository.GetBoard(boardId);
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
        return Ok(board);
    }

    // Создать доску
    // POST api/boards
    [HttpPost]
    public IActionResult CreateBoard([FromBody] CreateBoardDTO param)
    {
        try
        {
            _repository.CreateBoard(param);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    // Удалить доску
    // DELETE api/boards/{boardId}
    [HttpDelete("{boardId}")]
    public IActionResult DeleteBoard(int boardId)
    {
        try
        {
            _repository.DeleteBoard(boardId);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    // Создать колонку
    // POST api/boards/{boardId}/column
    [HttpPost("{boardId}/column")]
    public IActionResult CreateColumn(int boardId, [FromBody] CreateColumnDTO param)
    {
        try
        {
            _repository.CreateColumn(boardId, param);
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
        return Ok();
    }

    // Редактировать колонку
    // PUT api/boards/column/{columnId}
    [HttpPut("column/{columnId}")]
    public IActionResult EditColumn(int columnId, [FromBody] EditColumnDTO param)
    {
        try
        {
            _repository.EditColumn(columnId, param);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    // Удалить колонку
    // DELETE api/boards/column/{columnId}
    [HttpDelete("column/{columnId}")]
    public IActionResult DeleteColumn(int columnId)
    {
        try
        {
            _repository.DeleteColumn(columnId);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    // Создать задачу
    // POST api/boards/{boardId}/task
    [HttpPost("{boardId}/task")]
    public IActionResult CreateTask(int boardId, [FromBody] CreateTaskDTO param)
    {
        try
        {
            _repository.CreateTask(boardId, param);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    // Редактировать задачу
    // PUT api/boards/task/{taskId}
    [HttpPut("task/{taskId}")]
    public IActionResult EditTask(int taskId, [FromBody] EditTaskDTO param)
    {
        try
        {
            _repository.EditTask(taskId, param);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    // Удалить задачу
    // DELETE api/boards/task/{taskId}
    [HttpDelete("task/{taskId}")]
    public IActionResult DeleteTask(int taskId)
    {
        try
        {
            _repository.DeleteTask(taskId);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }

    // Переместить задачу из колонки в колонку
    // PUT api/boards/columns/{columnId}/task/{taskId}
    [HttpPut("column/{columnId}/task/{taskId}")] 
    public IActionResult TransferTask(int taskId, int columnId)
    {
        try
        {
            _repository.TransferTask(taskId, columnId);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }
}
