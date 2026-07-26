using System.Collections.Generic;
using FAD_TASK.Models;

namespace FAD_TASK.Data
{
    public static class FakeDatabase
    {
        // In-memory list to store tasks
        public static List<TaskItem> Tasks { get; } = new List<TaskItem>();

        // Auto-increment ID counter
        private static int _nextId = 1;

        // Hardcoded fake user credentials
        public const string FakeUserEmail = "admin@fad.com";
        public const string FakeUserPassword = "123456";

        // Helper to generate new task ID
        public static int GenerateId()
        {
            return _nextId++;
        }
    }
}
