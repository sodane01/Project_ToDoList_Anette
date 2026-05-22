public class TaskDisplay
{
    public void DisplayTasksWithMenu(List<TodoTask> tasks)
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------------------------------------------------------------------");

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(
            $"{"Id",-8}" +
            $"{"Title",-30}" +
            $"{"Project",-25}" +
            $"{"Due date",-15}" +
            $"{"Status",-15}");
        Console.ResetColor();

        Console.WriteLine("----------------------------------------------------------------------------------------------------");

        foreach (var task in tasks)
        {
            string status = task.IsDone ? "Done" : "Not done";

            Console.WriteLine(
                $"{task.Id,-8}" +
                $"{task.Title,-30}" +
                $"{task.Project,-25}" +
                $"{task.DueDate,-15:yyyy-MM-dd}" +
                $"{status,-15}");
        }

        Console.WriteLine("----------------------------------------------------------------------------------------------------");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("1. Add task    2. Edit task    3. Sort tasks    4. Search tasks    5. Export file    6. Exit");
        Console.ResetColor();
        Console.WriteLine();
    }
}