//public class TaskDisplay
//{
//    public void DisplayTasksWithMenu(List<TodoTask> tasks)
//    {
//        Console.Clear();

//        Console.WriteLine("----------------------------------------------------------------------------------------------------");

//        Console.ForegroundColor = ConsoleColor.Cyan;
//        Console.WriteLine(
//            $"{"Id",-8}" +
//            $"{"Title",-30}" +
//            $"{"Project",-25}" +
//            $"{"Due date",-15}" +
//            $"{"Status",-15}");
//        Console.ResetColor();

//        Console.WriteLine("----------------------------------------------------------------------------------------------------");

//        foreach (var task in tasks)
//        {
//            string status = task.IsDone ? "Done" : "Not done";

//            Console.WriteLine(
//                $"{task.Id,-8}" +
//                $"{task.Title,-30}" +
//                $"{task.Project,-25}" +
//                $"{task.DueDate,-15:yyyy-MM-dd}" +
//                $"{status,-15}");
//        }

//        Console.WriteLine("----------------------------------------------------------------------------------------------------");
//        Console.WriteLine();
//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine("1. Add task    2. Edit task    3. Sort tasks    4. Search tasks     5. Remove task    6. Export file    7. Exit");
//        Console.ResetColor();
//        Console.WriteLine();
//    }
//}

public class TaskDisplay
{
    // Displays the task list and main application menu
    public void DisplayTasksWithMenu(List<TodoTask> tasks)
    {
        // Clears the console before redrawing the updated task view
        Console.Clear();

        Console.WriteLine("----------------------------------------------------------------------------------------------------");

        // Display table header in a different color for improved readability
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine(
            $"{"Id",-8}" +
            $"{"Title",-30}" +
            $"{"Project",-25}" +
            $"{"Due date",-15}" +
            $"{"Status",-15}");

        Console.ResetColor();

        Console.WriteLine("----------------------------------------------------------------------------------------------------");


        // Display all tasks in a formatted table layout
        foreach (var task in tasks)
        {
            // Convert boolean status into user-friendly text
            string status =
                task.IsDone ? "Done" : "Not done";

            Console.WriteLine(
                $"{task.Id,-8}" +
                $"{task.Title,-30}" +
                $"{task.Project,-25}" +
                $"{task.DueDate,-15:yyyy-MM-dd}" +
                $"{status,-15}");
        }

        Console.WriteLine("----------------------------------------------------------------------------------------------------");
        Console.WriteLine();


        // Display main menu options
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine(
            "1. Add task    " +
            "2. Edit task    " +
            "3. Sort tasks    " +
            "4. Search tasks     " +
            "5. Remove task    " +
            "6. Export file    " +
            "7. Exit");

        Console.ResetColor();

        Console.WriteLine();
    }
}