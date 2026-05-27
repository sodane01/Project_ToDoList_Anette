
//using System.Linq;

//public class TaskSearch
//{
//    private readonly TaskValidator validator = new();
//    private readonly TaskDisplay display = new();

//    public void SearchMenu(List<TodoTask> tasks)
//    {
//        if (tasks.Count == 0)
//        {
//            Console.WriteLine("No tasks available.");
//            Console.ReadKey();
//            return;
//        }

//        while (true)
//        {
//            Console.Clear();

//            Console.WriteLine("SEARCH TASKS");
//            Console.WriteLine("----------------------------");
//            Console.WriteLine("1. Search by project");
//            Console.WriteLine("2. Search by due date");
//            Console.WriteLine("3. Return to main menu");
//            Console.WriteLine();

//            Console.Write("Choose option: ");
//            string choice = Console.ReadLine()?.Trim() ?? "";

//            switch (choice)
//            {
//                case "1":
//                    SearchByProject(tasks);
//                    break;

//                case "2":
//                    SearchByDueDate(tasks);
//                    break;

//                case "3":
//                    return;

//                default:
//                    Console.WriteLine("Invalid choice. Please choose 1, 2 or 3.");
//                    Console.ReadKey();
//                    continue;
//            }


//        }
//    }

//    public bool SearchByProject(List<TodoTask> tasks)
//    {
//        while (true)
//        {
//            Console.Write("Enter project name: ");

//            string project =
//                validator.ValidateProject(
//                    Console.ReadLine()?.Trim() ?? "");

//            var results = tasks
//                .Where(t =>
//                    t.Project.Contains(
//                        project,
//                        StringComparison.OrdinalIgnoreCase))
//                .ToList();

//            if (results.Count > 0)
//            {
//                Console.WriteLine();
//                Console.WriteLine("Search results:");

//                display.DisplayTasksWithMenu(results);

//                return true;
//            }

//            Console.WriteLine();
//            Console.WriteLine("No matching tasks found.");

//            Console.Write("Do you want to search again? (y/n): ");

//            string again =
//                Console.ReadLine()?.Trim() ?? "";

//            while (!again.Equals("y", StringComparison.OrdinalIgnoreCase) &&
//                   !again.Equals("n", StringComparison.OrdinalIgnoreCase))
//            {
//                Console.WriteLine("Invalid choice.");

//                Console.Write("Do you want to search again? (y/n): ");

//                again =
//                    Console.ReadLine()?.Trim() ?? "";
//            }

//            if (again.Equals("n", StringComparison.OrdinalIgnoreCase))
//            {
//                return false;
//            }
//        }
//    }

//    public bool SearchByDueDate(List<TodoTask> tasks)
//    {
//        while (true)
//        {
//            Console.Write("Enter due date (yyyy-MM-dd): ");

//            DateTime dueDate =
//                validator.ValidateDueDate(
//                    Console.ReadLine()?.Trim() ?? "");

//            var results = tasks
//                .Where(t => t.DueDate.Date == dueDate.Date)
//                .ToList();

//            if (results.Count > 0)
//            {
//                Console.WriteLine();
//                Console.WriteLine("Search results:");

//                display.DisplayTasksWithMenu(results);

//                return true;
//            }

//            Console.WriteLine();
//            Console.WriteLine("No matching tasks found.");

//            Console.Write("Do you want to search again? (y/n): ");

//            string again =
//                Console.ReadLine()?.Trim() ?? "";

//            while (!again.Equals("y", StringComparison.OrdinalIgnoreCase) &&
//                   !again.Equals("n", StringComparison.OrdinalIgnoreCase))
//            {
//                Console.WriteLine("Invalid choice.");

//                Console.Write("Do you want to search again? (y/n): ");

//                again =
//                    Console.ReadLine()?.Trim() ?? "";
//            }

//            if (again.Equals("n", StringComparison.OrdinalIgnoreCase))
//            {
//                return false;
//            }
//        }
//    }
//}

using System.Linq;

public class TaskSearch
{
    // Handles validation of user input during search operations
    private readonly TaskValidator validator = new();

    // Used to display search results in the console
    private readonly TaskDisplay display = new();


    // Displays the search menu and handles user navigation
    public void SearchMenu(List<TodoTask> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            Console.ReadKey();

            return;
        }

        while (true)
        {
            Console.Clear();

            Console.WriteLine("SEARCH TASKS");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Search by project");
            Console.WriteLine("2. Search by due date");
            Console.WriteLine("3. Return to main menu");
            Console.WriteLine();

            Console.Write("Choose option: ");

            string choice =
                Console.ReadLine()?.Trim() ?? "";

            switch (choice)
            {
                case "1":

                    SearchByProject(tasks);

                    break;


                case "2":

                    SearchByDueDate(tasks);

                    break;


                case "3":

                    return;


                default:

                    Console.WriteLine(
                        "Invalid choice. Please choose 1, 2 or 3.");

                    Console.ReadKey();

                    continue;
            }
        }
    }


    // Searches tasks by project name
    public bool SearchByProject(List<TodoTask> tasks)
    {
        while (true)
        {
            Console.Write("Enter project name: ");

            string project =
                validator.ValidateProject(
                    Console.ReadLine()?.Trim() ?? "");

            // Find all tasks matching the entered project name
            var results = tasks
                .Where(t =>
                    t.Project.Contains(
                        project,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (results.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Search results:");

                display.DisplayTasksWithMenu(results);

                return true;
            }

            Console.WriteLine();
            Console.WriteLine("No matching tasks found.");

            Console.Write(
                "Do you want to search again? (y/n): ");

            string again =
                Console.ReadLine()?.Trim() ?? "";

            // Keep asking until the user enters y or n
            while (!again.Equals(
                       "y",
                       StringComparison.OrdinalIgnoreCase) &&
                   !again.Equals(
                       "n",
                       StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid choice.");

                Console.Write(
                    "Do you want to search again? (y/n): ");

                again =
                    Console.ReadLine()?.Trim() ?? "";
            }

            if (again.Equals(
                "n",
                StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
        }
    }


    // Searches tasks by due date
    public bool SearchByDueDate(List<TodoTask> tasks)
    {
        while (true)
        {
            Console.Write(
                "Enter due date (yyyy-MM-dd): ");

            DateTime dueDate =
                validator.ValidateDueDate(
                    Console.ReadLine()?.Trim() ?? "");

            // Find all tasks matching the entered due date
            var results = tasks
                .Where(t =>
                    t.DueDate.Date == dueDate.Date)
                .ToList();

            if (results.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Search results:");

                display.DisplayTasksWithMenu(results);

                return true;
            }

            Console.WriteLine();
            Console.WriteLine("No matching tasks found.");

            Console.Write(
                "Do you want to search again? (y/n): ");

            string again =
                Console.ReadLine()?.Trim() ?? "";

            // Keep asking until the user enters y or n
            while (!again.Equals(
                       "y",
                       StringComparison.OrdinalIgnoreCase) &&
                   !again.Equals(
                       "n",
                       StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid choice.");

                Console.Write(
                    "Do you want to search again? (y/n): ");

                again =
                    Console.ReadLine()?.Trim() ?? "";
            }

            if (again.Equals(
                "n",
                StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
        }
    }
}