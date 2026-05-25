List<TodoTask> tasks = new();

TaskDisplay display = new();
TaskManager taskManager = new();
TaskSorter taskSorter = new();

bool running = true;

//List<TodoTask> testTasks = new()
//{
//    new TodoTask(1, "wash dishes", "kitchen", new DateTime(2026, 6, 1), false),
//    new TodoTask(2, "take out trash", "cleaning", new DateTime(2026, 6, 1), true),
//    new TodoTask(3, "vacuum living room", "cleaning", new DateTime(2026, 6, 2), false),
//    new TodoTask(4, "do laundry", "laundry", new DateTime(2026, 6, 2), false),
//    new TodoTask(5, "clean bathroom", "bathroom", new DateTime(2026, 6, 3), true),
//    new TodoTask(6, "mop kitchen floor", "kitchen", new DateTime(2026, 6, 3), false),
//    new TodoTask(7, "water plants", "garden", new DateTime(2026, 6, 4), false),
//    new TodoTask(8, "change bed sheets", "bedroom", new DateTime(2026, 6, 4), true),
//    new TodoTask(9, "organize closet", "bedroom", new DateTime(2026, 6, 5), false),
//    new TodoTask(10, "clean windows", "cleaning", new DateTime(2026, 6, 5), false),

//    new TodoTask(11, "dust shelves", "living room", new DateTime(2026, 6, 6), false),
//    new TodoTask(12, "feed cat", "pets", new DateTime(2026, 6, 6), true),
//    new TodoTask(13, "clean refrigerator", "kitchen", new DateTime(2026, 6, 7), false),
//    new TodoTask(14, "sort recycling", "cleaning", new DateTime(2026, 6, 7), true),
//    new TodoTask(15, "cook dinner", "kitchen", new DateTime(2026, 6, 8), false),
//    new TodoTask(16, "clean microwave", "kitchen", new DateTime(2026, 6, 8), false),
//    new TodoTask(17, "vacuum bedroom", "bedroom", new DateTime(2026, 6, 9), true),
//    new TodoTask(18, "wipe kitchen counters", "kitchen", new DateTime(2026, 6, 9), false),
//    new TodoTask(19, "pay electricity bill", "finance", new DateTime(2026, 6, 10), false),
//    new TodoTask(20, "clean shower drain", "bathroom", new DateTime(2026, 6, 10), true),

//    new TodoTask(21, "wash towels", "laundry", new DateTime(2026, 6, 11), false),
//    new TodoTask(22, "fold laundry", "laundry", new DateTime(2026, 6, 11), false),
//    new TodoTask(23, "clean oven", "kitchen", new DateTime(2026, 6, 12), true),
//    new TodoTask(24, "trim garden bushes", "garden", new DateTime(2026, 6, 12), false),
//    new TodoTask(25, "clean coffee machine", "kitchen", new DateTime(2026, 6, 13), false),
//    new TodoTask(26, "wash car", "garage", new DateTime(2026, 6, 13), true),
//    new TodoTask(27, "refill soap dispensers", "bathroom", new DateTime(2026, 6, 14), false),
//    new TodoTask(28, "clean mirrors", "bathroom", new DateTime(2026, 6, 14), false),
//    new TodoTask(29, "organize pantry", "kitchen", new DateTime(2026, 6, 15), true),
//    new TodoTask(30, "vacuum hallway", "cleaning", new DateTime(2026, 6, 15), false),

//    new TodoTask(31, "wash curtains", "laundry", new DateTime(2026, 6, 16), false),
//    new TodoTask(32, "clean tv screen", "living room", new DateTime(2026, 6, 16), true),
//    new TodoTask(33, "mow lawn", "garden", new DateTime(2026, 6, 17), false),
//    new TodoTask(34, "take dog for walk", "pets", new DateTime(2026, 6, 17), true),
//    new TodoTask(35, "clean sink", "bathroom", new DateTime(2026, 6, 18), false),
//    new TodoTask(36, "sort mail", "office", new DateTime(2026, 6, 18), false),
//    new TodoTask(37, "backup laptop", "office", new DateTime(2026, 6, 19), true),
//    new TodoTask(38, "clean keyboard", "office", new DateTime(2026, 6, 19), false),
//    new TodoTask(39, "wash pet bowls", "pets", new DateTime(2026, 6, 20), false),
//    new TodoTask(40, "declutter desk", "office", new DateTime(2026, 6, 20), true),

//    new TodoTask(41, "sweep balcony", "outdoor", new DateTime(2026, 6, 21), false),
//    new TodoTask(42, "replace light bulbs", "maintenance", new DateTime(2026, 6, 21), false),
//    new TodoTask(43, "clean under bed", "bedroom", new DateTime(2026, 6, 22), true),
//    new TodoTask(44, "wash pillows", "laundry", new DateTime(2026, 6, 22), false),
//    new TodoTask(45, "check smoke detector", "maintenance", new DateTime(2026, 6, 23), false),
//    new TodoTask(46, "organize cables", "office", new DateTime(2026, 6, 23), true),
//    new TodoTask(47, "clean shoe rack", "hallway", new DateTime(2026, 6, 24), false),
//    new TodoTask(48, "empty dishwasher", "kitchen", new DateTime(2026, 6, 24), true),
//    new TodoTask(49, "refill bird feeder", "garden", new DateTime(2026, 6, 25), false),
//    new TodoTask(50, "polish dining table", "dining room", new DateTime(2026, 6, 25), false)
//};

//using StreamWriter writer = new StreamWriter("tasks.csv");

//writer.WriteLine("Id,Title,Project,DueDate,IsDone");

//foreach (var task in testTasks)
//{
//    writer.WriteLine($"{task.Id},{task.Title},{task.Project},{task.DueDate:yyyy-MM-dd},{task.IsDone}");
//}

//Console.WriteLine(Path.GetFullPath("tasks.csv"));


//TaskManager taskManager = new();
//TaskDisplay display = new();
TaskStorage storage = new();


List<TodoTask> loadedTasks = storage.LoadTasks();
taskManager.SetTasks(loadedTasks);

List<TodoTask> currentView = taskManager.GetTasks();


while (running)
{
    display.DisplayTasksWithMenu(taskManager.GetTasks());

    Console.Write("Choose option: ");
    string choice = Console.ReadLine()?.Trim() ?? "";

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
            //taskManager.SearchTasks();
            break;

        case "5":
            taskManager.RemoveTask();
            storage.SaveTasks(taskManager.GetTasks());
            currentView = taskManager.GetTasks();
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
