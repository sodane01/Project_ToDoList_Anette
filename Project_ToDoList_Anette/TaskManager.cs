using System.Linq;
public class TaskManager
{
    private readonly TaskValidator validator = new();
    private readonly List<TodoTask> tasks = new();
    private int nextId = 1;

    public List<TodoTask> GetTasks()
    {
        return tasks;
    }

    public void AddTask()
    {
        Console.Write("Enter title: ");
        string title = validator.ValidateTitle(Console.ReadLine()?.Trim() ?? "");

        Console.Write("Enter project: ");
        string project = validator.ValidateProject(Console.ReadLine()?.Trim() ?? "");

        Console.Write("Enter due date (yyyy-MM-dd): ");
        DateTime dueDate = validator.ValidateDueDate(Console.ReadLine()?.Trim() ?? "");

        TodoTask task = new TodoTask(nextId, title, project, dueDate, false);

        tasks.Add(task);
        nextId++;

        Console.WriteLine("Task added successfully!");
        Console.ReadKey();
    }
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


        // TITLE
        Console.Write($"New title ({task.Title}): ");

        input = Console.ReadLine()?.Trim() ?? "";

        if (!string.IsNullOrWhiteSpace(input))
        {
            task.Title =
                validator.ValidateTitle(input);
        }


        // PROJECT
        Console.Write($"New project ({task.Project}): ");

        input = Console.ReadLine()?.Trim() ?? "";

        if (!string.IsNullOrWhiteSpace(input))
        {
            task.Project =
                validator.ValidateProject(input);
        }


        // DUE DATE
        Console.Write(
            $"New due date ({task.DueDate:yyyy-MM-dd}): ");

        input = Console.ReadLine()?.Trim() ?? "";

        if (!string.IsNullOrWhiteSpace(input))
        {
            task.DueDate =
                validator.ValidateDueDate(input);
        }


        // STATUS
        Console.Write(
            $"Is task done? ({(task.IsDone ? "y" : "n")}): ");

        input = Console.ReadLine()?.Trim() ?? "";

        if (!string.IsNullOrWhiteSpace(input))
        {
            task.IsDone =
                input.Equals("y",
                StringComparison.OrdinalIgnoreCase);
        }

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Task updated successfully!");
        Console.ResetColor();
    }
    public void RemoveTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.Write("Enter task ID to remove: ");
        string input = Console.ReadLine()?.Trim() ?? "";

        int id = validator.ValidateExistingId(input, tasks);

        TodoTask? task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }

        Console.WriteLine($"Are you sure you want to remove '{task.Title}'? y/n");
        string confirm = Console.ReadLine()?.Trim() ?? "";

        if (!confirm.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Remove cancelled.");
            return;
        }

        tasks.Remove(task);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Task removed successfully!");
        Console.ResetColor();
    }
    public void SetTasks(List<TodoTask> loadedTasks)
    {
        tasks.Clear();

        tasks.AddRange(loadedTasks);

        if (tasks.Count > 0)
        {
            nextId = tasks.Max(t => t.Id) + 1;
        }
    }
}