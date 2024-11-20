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
   git clone https://github.com/your-username/TaskWebAPI.git


# Project Setup Instructions

## 1. Open the Project in Visual Studio
- Open Visual Studio.
- Click on **File** > **Open** > **Project/Solution**.
- Select the `.sln` file from the cloned repository.

## 2. Restore NuGet Packages
- Go to **Tools** > **NuGet Package Manager** > **Manage NuGet Packages for Solution**.
- Click **Restore** to install all required dependencies.

## 3. Configure Settings (if applicable)
- Open `appsettings.json` (or `web.config` if applicable).
- Set up any environment-specific configurations such as database connection strings, API keys, etc.

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



