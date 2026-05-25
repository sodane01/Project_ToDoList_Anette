
using System.Linq;
public class TaskSorter
{
    private readonly TaskDisplay display = new();
    public List<TodoTask> SortMenu(List<TodoTask> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            Console.ReadKey();

            return tasks;
        }

        List<TodoTask> currentView = tasks;

        while (true)
        {
            Console.Clear();

            Console.WriteLine("SORT / FILTER TASKS");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Sort by project");
            Console.WriteLine("2. Sort by due date");
            Console.WriteLine("3. Filter by status");
            Console.WriteLine("4. Return to main menu");
            Console.WriteLine();

            Console.Write("Choose option: ");

            string choice =
                Console.ReadLine()?.Trim() ?? "";

            switch (choice)
            {
                case "1":

                    currentView =
                        SortByProject(
                            currentView,
                            AskAscending());

                    display.DisplayTasksWithMenu(currentView);

                    break;

                case "2":

                    currentView =
                        SortByDueDate(
                            currentView,
                            AskAscending());

                    display.DisplayTasksWithMenu(currentView);

                    break;

                case "3":

                    currentView =
                        FilterByStatus(
                            currentView,
                            AskStatus());

                    if (currentView.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine(
                            "No tasks matched the filter.");

                        Console.ReadKey();

                        return tasks;
                    }

                    display.DisplayTasksWithMenu(currentView);


                    break;

                case "4":

                    return currentView;

                default:

                    Console.WriteLine();
                    Console.WriteLine("Invalid choice.");

                    Console.ReadKey();

                    continue;
            }

            Console.WriteLine();
            Console.Write(
                "Do you want to sort/filter again? (y/n): ");

            string again =
                Console.ReadLine()?.Trim() ?? "";

            if (again.Equals(
                "n",
                StringComparison.OrdinalIgnoreCase))
            {
                return currentView;
            }
        }
    }


    public List<TodoTask> SortByProject(
        List<TodoTask> tasks,
        bool ascending)
    {
        return ascending
            ? tasks.OrderBy(t => t.Project).ToList()
            : tasks.OrderByDescending(t => t.Project).ToList();
    }


    public List<TodoTask> SortByDueDate(
        List<TodoTask> tasks,
        bool ascending)
    {
        return ascending
            ? tasks.OrderBy(t => t.DueDate).ToList()
            : tasks.OrderByDescending(t => t.DueDate).ToList();
    }


    public List<TodoTask> FilterByStatus(
        List<TodoTask> tasks,
        bool isDone)
    {
        return tasks
            .Where(t => t.IsDone == isDone)
            .ToList();
    }


    private bool AskAscending()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Ascending");
            Console.WriteLine("2. Descending");

            Console.Write("Choose order: ");

            string input =
                Console.ReadLine()?.Trim() ?? "";

            switch (input)
            {
                case "1":
                    return true;

                case "2":
                    return false;

                default:

                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }


    private bool AskStatus()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Done");
            Console.WriteLine("2. Not done");

            Console.Write("Choose status: ");

            string input =
                Console.ReadLine()?.Trim() ?? "";

            switch (input)
            {
                case "1":
                    return true;

                case "2":
                    return false;

                default:

                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

