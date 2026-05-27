

using System.Linq;

public class TaskManager
{
    // Handles all input validation for task operations
    private readonly TaskValidator validator = new();

    // Stores all tasks managed by the application
    private readonly List<TodoTask> tasks = new();

    // Keeps track of the next available task ID
    private int nextId = 1;


    // Returns the current task list
    public List<TodoTask> GetTasks()
    {
        return tasks;
    }


    // Creates a new task and adds it to the task list
    public void AddTask()
    {
        Console.Write("Enter title: ");
        string title =
            validator.ValidateTitle(
                Console.ReadLine()?.Trim() ?? "");

        Console.Write("Enter project: ");
        string project =
            validator.ValidateProject(
                Console.ReadLine()?.Trim() ?? "");

        Console.Write("Enter due date (yyyy-MM-dd): ");
        DateTime dueDate =
            validator.ValidateDueDate(
                Console.ReadLine()?.Trim() ?? "");

        // New tasks are created as not done by default
        TodoTask task =
            new TodoTask(
                nextId,
                title,
                project,
                dueDate,
                false);

        tasks.Add(task);

        // Prepare the next unique ID
        nextId++;

        Console.WriteLine("Task added successfully!");
        Console.WriteLine("Click enter to continue...");

        Console.ReadKey();
    }


    // Allows the user to edit an existing task
    public void EditTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.Write("Enter task ID to edit: ");

        string input =
            Console.ReadLine()?.Trim() ?? "";

        int id =
            validator.ValidateExistingId(input, tasks);

        TodoTask? task =
            tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }


        // Leave input empty to keep the current title
        Console.Write($"New title ({task.Title}): ");

        input = Console.ReadLine()?.Trim() ?? "";

        if (!string.IsNullOrWhiteSpace(input))
        {
            task.Title =
                validator.ValidateTitle(input);
        }


        // Leave input empty to keep the current project
        Console.Write($"New project ({task.Project}): ");

        input = Console.ReadLine()?.Trim() ?? "";

        if (!string.IsNullOrWhiteSpace(input))
        {
            task.Project =
                validator.ValidateProject(input);
        }


        // Leave input empty to keep the current due date
        Console.Write(
            $"New due date ({task.DueDate:yyyy-MM-dd}): ");

        input = Console.ReadLine()?.Trim() ?? "";

        if (!string.IsNullOrWhiteSpace(input))
        {
            task.DueDate =
                validator.ValidateDueDate(input);
        }


        // Leave input empty to keep the current status
        Console.Write(
            $"Is task done? y/n ({(task.IsDone ? "y" : "n")}): ");

        input = Console.ReadLine()?.Trim() ?? "";

        if (!string.IsNullOrWhiteSpace(input))
        {
            task.IsDone =
                input.Equals(
                    "y",
                    StringComparison.OrdinalIgnoreCase);
        }

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Task updated successfully!");
        Console.ResetColor();
    }


    // Removes a task from the list after user confirmation
    public void RemoveTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.Write("Enter task ID to remove: ");

        string input =
            Console.ReadLine()?.Trim() ?? "";

        int id =
            validator.ValidateExistingId(input, tasks);

        TodoTask? task =
            tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }

        Console.WriteLine(
            $"Are you sure you want to remove '{task.Title}'? y/n");

        string confirm =
            Console.ReadLine()?.Trim() ?? "";

        if (!confirm.Equals(
            "y",
            StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Remove cancelled.");
            return;
        }

        tasks.Remove(task);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Task removed successfully!");
        Console.ResetColor();
    }


    // Replaces the current task list with tasks loaded from storage
    public void SetTasks(List<TodoTask> loadedTasks)
    {
        tasks.Clear();

        tasks.AddRange(loadedTasks);

        // Ensures new tasks continue with a unique ID after loading saved tasks
        if (tasks.Count > 0)
        {
            nextId =
                tasks.Max(t => t.Id) + 1;
        }
    }
}