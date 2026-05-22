List<TodoTask> tasks = new();

TaskDisplay display = new();
TaskManager taskManager = new();

bool running = true;

while (running)
{
    display.DisplayTasksWithMenu(taskManager.GetTasks());

    Console.Write("Choose option: ");
    string choice = Console.ReadLine()?.Trim() ?? "";

    switch (choice)
    {
        case "1":
            taskManager.AddTask();
            break;

        case "2":
            taskManager.EditTask();
            break;

        case "3": 
            //taskManager.SortTasks();
            break;

        case "4":
            //taskManager.SearchTasks();
            break;

        case "5":
            taskManager.RemoveTask();
            break;

        case "6":
            //taskManager.ExportTasksToFile();
            break;

        case "7":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid choice.");
            Console.ReadKey();
            break;
    }
}

