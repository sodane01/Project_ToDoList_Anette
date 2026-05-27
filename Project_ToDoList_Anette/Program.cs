//using System.ComponentModel.DataAnnotations;

//List<TodoTask> tasks = new();

//TaskDisplay display = new();
//TaskManager taskManager = new();
//TaskSorter taskSorter = new();
//TaskSearch search = new();

//bool running = true;

//TaskStorage storage = new();


//List<TodoTask> loadedTasks = storage.LoadTasks();
//taskManager.SetTasks(loadedTasks);

//List<TodoTask> currentView = taskManager.GetTasks();


//while (running)
//{
//    display.DisplayTasksWithMenu(taskManager.GetTasks());

//    Console.Write("Choose option: ");
//    string choice = Console.ReadLine()?.Trim() ?? "";

//    switch (choice)
//    {
//        case "1":
//            taskManager.AddTask();
//            storage.SaveTasks(taskManager.GetTasks());
//            currentView = taskManager.GetTasks();
//            break;

//        case "2":
//            taskManager.EditTask();
//            storage.SaveTasks(taskManager.GetTasks());
//            currentView = taskManager.GetTasks();
//            break;

//        case "3": 
//            taskSorter.SortMenu(taskManager.GetTasks());
//            break;

//        case "4":
//            search.SearchMenu(taskManager.GetTasks());
//            break;

//        case "5":
//            taskManager.RemoveTask();
//            storage.SaveTasks(taskManager.GetTasks());
//            currentView = taskManager.GetTasks();
//            break;

//        case "6":
//            ITaskExporter exporter =
//        new CsvExporter();

//            exporter.Export(
//                taskManager.GetTasks());

//            Console.WriteLine();
//            Console.Write(
//                "Press Enter to return to menu...");

//            Console.ReadLine();

//            break;

//        case "7":
//            running = false;
//            break;

//        default:
//            Console.WriteLine("Invalid choice.");
//            Console.ReadKey();
//            break;
//    }
//}

// Main task list view currently displayed to the user
List<TodoTask> currentView = new();

// Handles task display in the console UI
TaskDisplay display = new();

// Handles CRUD operations and task management
TaskManager taskManager = new();

// Handles sorting and filtering functionality
TaskSorter taskSorter = new();

// Handles task search functionality
TaskSearch search = new();

// Handles CSV save/load functionality
TaskStorage storage = new();

// Controls the main application loop
bool running = true;


// Load saved tasks from CSV storage
List<TodoTask> loadedTasks = storage.LoadTasks();

// Pass loaded tasks to TaskManager
taskManager.SetTasks(loadedTasks);

// Set initial view to all loaded tasks
currentView = taskManager.GetTasks();


// Main application loop
while (running)
{
    // Display current task list and menu
    display.DisplayTasksWithMenu(currentView);

    Console.Write("Choose option: ");

    string choice =
        Console.ReadLine()?.Trim() ?? "";

    switch (choice)
    {
        // Add task
        case "1":

            taskManager.AddTask();

            // Save updated task list
            storage.SaveTasks(
                taskManager.GetTasks());

            // Refresh current view
            currentView =
                taskManager.GetTasks();

            break;


        // Edit task
        case "2":

            taskManager.EditTask();

            storage.SaveTasks(
                taskManager.GetTasks());

            currentView =
                taskManager.GetTasks();

            break;


        // Sort or filter tasks
        case "3":

            currentView =
                taskSorter.SortMenu(
                    taskManager.GetTasks());

            break;


        // Search tasks
        case "4":

            search.SearchMenu(
                taskManager.GetTasks());

            break;


        // Remove task
        case "5":

            taskManager.RemoveTask();

            storage.SaveTasks(
                taskManager.GetTasks());

            currentView =
                taskManager.GetTasks();

            break;


        // Export tasks to CSV
        case "6":

            ITaskExporter exporter =
                new CsvExporter();

            exporter.Export(
                taskManager.GetTasks());

            Console.WriteLine();

            Console.Write(
                "Press Enter to return to menu...");

            Console.ReadLine();

            break;


        // Exit application
        case "7":

            running = false;

            break;


        // Handle invalid menu input
        default:

            Console.WriteLine(
                "Invalid choice.");

            Console.ReadKey();

            break;
    }
}
