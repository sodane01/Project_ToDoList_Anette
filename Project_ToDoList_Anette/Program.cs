using System.ComponentModel.DataAnnotations;

List<TodoTask> tasks = new();

TaskDisplay display = new();
TaskManager taskManager = new();
TaskSorter taskSorter = new();
TaskSearch search = new();

bool running = true;

TaskStorage storage = new();


List<TodoTask> loadedTasks = storage.LoadTasks();
taskManager.SetTasks(loadedTasks);

List<TodoTask> currentView = taskManager.GetTasks();


while (running)
{
    display.DisplayTasksWithMenu(taskManager.GetTasks());

    Console.Write("Choose option: ");
    string choice = Console.ReadLine()?.Trim() ?? "";

    TaskValidator validator = new TaskValidator();
    switch (choice)
    {
        case "1":
            taskManager.AddTask();
            storage.SaveTasks(taskManager.GetTasks());
            currentView = taskManager.GetTasks();
            break;

        case "2":
            taskManager.EditTask();
            storage.SaveTasks(taskManager.GetTasks());
            currentView = taskManager.GetTasks();
            break;

        case "3": 
            taskSorter.SortMenu(taskManager.GetTasks());
            break;

        case "4":
            search.SearchMenu(taskManager.GetTasks());
            break;

        case "5":
            taskManager.RemoveTask();
            storage.SaveTasks(taskManager.GetTasks());
            currentView = taskManager.GetTasks();
            break;

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

        case "7":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid choice.");
            Console.ReadKey();
            break;
    }
}
