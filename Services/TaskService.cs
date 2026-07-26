using System.Collections.Generic;
using System.Linq;
using FAD_TASK.Data;
using FAD_TASK.DTOs;
using FAD_TASK.Models;

namespace FAD_TASK.Services
{
    public class TaskService : ITaskService
    {
        public TaskResponseDto CreateTask(CreateTaskRequestDto request)
        {
            // Simple mapping from DTO to Model
            var task = new TaskItem
            {
                Id = FakeDatabase.GenerateId(),
                Title = request.Title,
                Description = request.Description,
                IsCompleted = false
            };

            // Save to memory
            FakeDatabase.Tasks.Add(task);

            // Simple mapping back to DTO
            return new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted
            };
        }

        public IEnumerable<TaskResponseDto> GetAllTasks()
        {
            // Simple mapping of list items to DTOs
            return FakeDatabase.Tasks.Select(task => new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted
            });
        }
    }
}
