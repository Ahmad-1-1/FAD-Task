using System.Collections.Generic;
using FAD_TASK.DTOs;

namespace FAD_TASK.Services
{
    public interface ITaskService
    {
        TaskResponseDto CreateTask(CreateTaskRequestDto request);
        IEnumerable<TaskResponseDto> GetAllTasks();
    }
}
