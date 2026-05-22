List<TodoTask> tasks = new();

TaskDisplay display = new();

bool running = true;

while (running)
{
    display.DisplayTasksWithMenu(tasks);

    Console.Write("Choose option: ");
    string choice = Console.ReadLine()?.Trim() ?? "";

    switch (choice)
    {
        case "1":
            // Add task later
            break;

        case "6":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid choice.");
            Console.ReadKey();
            break;
    }
}