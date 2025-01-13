# Task Web API

This repository contains the **Task Web API**, a .NET project built using ASP.NET MVC/Web API. It provides endpoints to perform task-related operations and includes integrated Swagger documentation for easy testing.

---

## Features
- Task management API
- Integrated Swagger for API documentation and testing
- Built using ASP.NET Web API in Visual Studio

---

## Getting Started

### Prerequisites
Before you start, ensure you have the following installed on your system:
1. [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
2. [.NET Framework or .NET Core SDK](https://dotnet.microsoft.com/download)
3. [Git](https://git-scm.com/)

---

### Steps to Download the Project
1. Clone the repository:
   ```bash
   git clone https://github.com/pushpakveer/TaskWebAPI.git


# Project Setup Instructions

## 1. Open the Project in Visual Studio
- Open Visual Studio.
- Click on **File** > **Open** > **Project/Solution**.
- Select the `.sln` file from the cloned repository.

## 2. Restore NuGet Packages
- Go to **Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution**.
- Click **Restore** to install all required dependencies.

## 3. Configure Settings (if applicable)
- Open `appsettings.json` check for JWT credentials and keys.

## 4. Build the Project
- In Visual Studio, click **Build** > **Build Solution** to ensure that the project builds successfully.

---

By following these steps, you will have the project set up and ready to run.

# Running the Project

## 1. Set the Startup Project
- Right-click the solution in **Solution Explorer**.
- Select **Set Startup Project** and ensure the API project is selected.

## 2. Start the Project
- Click the **Run** button in Visual Studio (or press **F5**).
- The project will launch, and Swagger will open in your default browser.

---

This will run the project and provide you with an interface to interact with the API through Swagger.

# Swagger UI

Once the project is running, Swagger UI will be accessible at:

http://localhost:<port>/swagger

Replace `<port>` with the actual port number shown in the Visual Studio Output.

In the Swagger UI:

1. **Authenticate API Call**: 
   - First, call the authentication API to get the JWT token.
   - In the request header, use the API key `"ApiKey": "12345-API-KEY-67890"`.
   
2. **Authorize Swagger UI**:
   - After calling the authentication API, you will receive the JWT token.
   - Go to the Swagger UI, and at the top-right corner, click on the **Authorize** button.
   - In the authorization dialog, enter `Bearer <JWT Token>` (replace `<JWT Token>` with the actual token received from the authentication API).

3. **Test API Endpoints**:
   - After authorization, you can now explore and test the available API endpoints directly from the interface.

## Packages Used
1. **Microsoft.AspNetCore.Authentication.JwtBearer**  
   This package is used to implement JWT authentication in the API. It helps secure the API by validating the JWT token in the request header and ensuring that only authorized users can access certain endpoints.

2. **FluentValidation**  
   FluentValidation is used for input validation of the data passed in API requests. It provides a fluent interface to define validation rules and ensures that the incoming data is valid before it is processed.

## Architecture Pattern
**Repository Pattern**  
The Repository Pattern is used to separate the data access logic from the business logic. The API uses repositories to interact with the data layer, ensuring that the business logic is not tightly coupled with data access code. This improves testability, maintainability, and separation of concerns within the application.

## API Endpoints

### 1. **GET /tasks**
   - Retrieves all tasks.

### 2. **GET /tasks/{id}**
   - Retrieves a specific task by its ID.

### 3. **POST /tasks**
   - Creates a new task. Requires a request body with the following properties:
     - `title` (string)
     - `description` (string)
     - `due_date` (date)
     - `status` (enum: "pending", "in_progress", "completed")

### 4. **PUT /tasks/{id}**
   - Updates an existing task. Requires a request body with the updated task properties.

### 5. **DELETE /tasks/{id}**
   - Deletes a task by its ID.

### 6. **PATCH /tasks/{id}/complete**
   - Marks a task as complete.

## Task Properties
Each task has the following properties:
- `id` (unique identifier)
- `title` (string)
- `description` (string)
- `due_date` (date)
- `status` (enum: "pending", "in_progress", "completed")
- `created_at` (timestamp)
- `updated_at` (timestamp)

## Usage

### JWT Authentication
To access protected endpoints, a valid JWT token must be provided in the `Authorization` header with the format:  
`Bearer <your_jwt_token_here>`

## Contact

For any doubts or queries, feel free to reach out to me at:

**Email**: pushpakveer19@gmail.com 





