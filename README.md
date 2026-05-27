# Todo List Console Application

A task management console application built in C# using object-oriented programming principles and UML-driven design.

The application allows users to create, edit, remove, search, sort, and export tasks while maintaining persistent storage using CSV files.

---

# Features

- Add tasks
- Edit tasks
- Remove tasks
- Search tasks
    - Search by project
    - Search by due date
- Sort and filter tasks
    - Sort by project
    - Sort by due date
    - Filter by status
- CSV export
- Persistent task storage
- Input validation with retry logic
- Console-based user interface
- UML-based architecture

---

# Technologies Used

- C#
- .NET 10.0
- Console Application
- Object-Oriented Programming (OOP)
- CSV File Handling

---

# System Architecture

The application follows separation of concerns principles and is divided into dedicated classes with specific responsibilities.

## Main Classes

| Class | Responsibility |
|---|---|
| `TodoTask` | Task model |
| `TaskManager` | CRUD operations and task management |
| `TaskDisplay` | Console UI and task visualization |
| `TaskValidator` | Input validation |
| `TaskSorter` | Sorting and filtering |
| `TaskSearch` | Search functionality |
| `TaskStorage` | Save/load tasks from CSV |
| `ITaskExporter` | Export interface |
| `CsvExporter` | CSV export implementation |

---

# UML Diagram

![UML Diagram](./images/uml_diagram.png)

---

# Activity Diagram


![Activity Diagram](C:\Users\user\Desktop\Project_ToDoList/activity_diagram.png)

---

# How to Run the Project

1. Clone the repository

```bash
git clone <repository-url>
```

2. Open the solution in Visual Studio

3. Build and run the project

4. The application will automatically:
   - load tasks from CSV storage
   - display the task list
   - show the main menu

---

# Example Functionality

The application supports:

- Creating tasks with:
  - title
  - project
  - due date
  - status

- Editing existing tasks

- Removing tasks

- Sorting and filtering tasks

- Searching tasks by:
  - project
  - due date

- Exporting tasks to CSV

---

# Future Improvements

Potential future improvements include:

- JSON export
- XML export
- Priority levels
- Categories/tags
- User authentication
- GUI version
- Database integration
- Reminder notifications
- Overdue task highlighting
- Unit testing

---

# What I Learned

During this project I practiced:

- Object-oriented programming
- Separation of concerns
- UML design
- CRUD operations
- File handling
- Validation patterns
- Interfaces and abstraction
- Console UI design
- Program flow and menu systems

---

# Author

Created by Anette Lindgren Söderström
