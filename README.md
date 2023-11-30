# Todolis Project

## Overview

Todolis is a modern web application developed using ASP.NET Core for the backend and Angular (TypeScript) for the frontend. The project is a task management tool designed to help users organize and manage their daily tasks efficiently.

## Features

- **Authentication:** Todolis implements secure user authentication based on JWT tokens. Users can register, log in, and securely access their personalized task management environment.

- **Task Management:** The application allows users to create, update, and delete tasks. Each task can have details such as a title, description, due date, and priority level.

- **Dependency Injection:** Todolis leverages the Dependency Injection pattern both on the backend (ASP.NET Core) and frontend (Angular). This ensures a modular and maintainable codebase, promoting scalability and testability.

- **Database Integration:** The backend utilizes Entity Framework Core for data access, incorporating migration mechanisms for smooth database schema updates. This ensures data consistency and enables seamless evolution of the application's data model.

## Technologies Used

- **Backend:**
  - ASP.NET Core
  - Entity Framework Core
  - JWT Token Authentication
  - Dependency Injection

- **Frontend:**
  - Angular
  - TypeScript
  - Dependency Injection

## Getting Started

To run Todolis locally, follow these steps:

1. Clone the repository:

   ```bash
   git clone https://github.com/maxpe3447/ToDoList.git
   ```

2. Navigate to the backend folder:

   ```bash
   cd ToDoList/ToDoList
   ```

3. Install backend dependencies:

   ```bash
   dotnet restore
   ```

4. Apply database migrations:

   ```bash
   dotnet ef database update
   ```

5. Run the backend:

   ```bash
   dotnet run
   ```

6. Navigate to the frontend folder:

   ```bash
   cd ../ToDoList/ClientApp
   ```

7. Install frontend dependencies:

   ```bash
   npm install
   ```

8. Run the frontend:

   ```bash
   ng serve
   ```

9. Open your web browser and go to `http://localhost:4200/` to access Todolis.
## Images
### Start Page
![Start Page](https://github.com/maxpe3447/ToDoList/blob/master/images/start_page.png)
### Registration page
![Registration](https://github.com/maxpe3447/ToDoList/blob/master/images/registration_page.png)
### User Tasks
![User tasks](https://github.com/maxpe3447/ToDoList/blob/master/images/add_user_tasks.png)

## More images [here](https://github.com/maxpe3447/ToDoList/blob/master/images/)

# GIF
![Example Image](https://github.com/maxpe3447/ToDoList/blob/master/images/Usage.gif)
