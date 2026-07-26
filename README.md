# FAD TASK - Task Management Web API

A clean, beginner-friendly, and understandable ASP.NET Core 8 Web API project built for the FAD Backend Qualification Challenge.

## Technologies Used
- **Runtime**: .NET 8.0
- **Framework**: ASP.NET Core Web API
- **Documentation**: Swagger/OpenAPI
- **Storage**: In-Memory (Static Lists)

## Project Structure
The code is organized in a straightforward, layered, junior-friendly structure inside the `FAD TASK` project folder:
```
FAD TASK/
├── Controllers/
│   ├── AuthController.cs      # Handles POST /login
│   └── TasksController.cs     # Handles GET /tasks, POST /tasks
├── Models/
│   └── TaskItem.cs            # Domain entity for a Task (Id, Title, Description, IsCompleted)
├── DTOs/
│   ├── LoginRequestDto.cs     # Credentials payload
│   ├── LoginResponseDto.cs    # Success/Failure message payload
│   ├── CreateTaskRequestDto.cs# New task payload
│   └── TaskResponseDto.cs     # Task details output payload
├── Services/
│   ├── IAuthService.cs        # Auth service interface
│   ├── AuthService.cs         # Validates admin credentials
│   ├── ITaskService.cs        # Task service interface
│   └── TaskService.cs         # Handles task business logic and in-memory persistence
└── Data/
    └── FakeDatabase.cs        # Static list acting as temporary database storage
```

## Setup & Running Instructions

### Prerequisite
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed on your system.

### Build the Project
Open a command line terminal at the repository root folder (`c:\Users\DELL\source\repos\FAD TASK`) and run:
```bash
dotnet build
```

### Run the Project
Start the development server:
```bash
dotnet run --project "FAD TASK"
```

Once running, you can test using the built-in HTTP request file [FAD TASK.http](file:///c:/Users/DELL/source/repos/FAD%20TASK/FAD%20TASK/FAD%20TASK.http) or visit Swagger UI (typically at `http://localhost:<port>/swagger`).

---

## API Endpoints

### 1. Login (`POST /login`)
Authenticates a user against fake database credentials (`admin@fad.com` / `123456`).

- **URL**: `/login`
- **Method**: `POST`
- **Request Body**:
  ```json
  {
    "email": "admin@fad.com",
    "password": "123456"
  }
  ```
- **Response (200 OK - Successful)**:
  ```json
  {
    "isSuccess": true,
    "message": "Login successful"
  }
  ```
- **Response (401 Unauthorized - Invalid Credentials)**:
  ```json
  {
    "isSuccess": false,
    "message": "Invalid email or password"
  }
  ```

### 2. Create Task (`POST /tasks`)
Creates a new task in-memory with automatic ID generation.

- **URL**: `/tasks`
- **Method**: `POST`
- **Request Body**:
  ```json
  {
    "title": "Complete FAD Challenge",
    "description": "Implement all endpoints and verify build"
  }
  ```
- **Response (201 Created)**:
  ```json
  {
    "id": 1,
    "title": "Complete FAD Challenge",
    "description": "Implement all endpoints and verify build",
    "isCompleted": false
  }
  ```

### 3. Get All Tasks (`GET /tasks`)
Retrieves all tasks stored in memory.

- **URL**: `/tasks`
- **Method**: `GET`
- **Response (200 OK)**:
  ```json
  [
    {
      "id": 1,
      "title": "Complete FAD Challenge",
      "description": "Implement all endpoints and verify build",
      "isCompleted": false
    }
  ]
  ```
