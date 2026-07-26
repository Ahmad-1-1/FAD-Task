using Microsoft.AspNetCore.Mvc;
using FAD_TASK.DTOs;
using FAD_TASK.Services;

namespace FAD_TASK.Controllers
{
    [ApiController]
    [Route("tasks")] // To map POST /tasks and GET /tasks
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] CreateTaskRequestDto request)
        {
            // Basic validation
            if (request == null)
            {
                return BadRequest("Task data is required.");
            }

            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return BadRequest("Task Title is required.");
            }

            if (string.IsNullOrWhiteSpace(request.Description))
            {
                return BadRequest("Task Description is required.");
            }

            var createdTask = _taskService.CreateTask(request);
            return StatusCode(201, createdTask); // 201 Created
        }
    }
}
