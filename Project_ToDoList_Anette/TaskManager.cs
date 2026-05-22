public class TaskManager
{
    private readonly TaskValidator validate = new();

    private List<TodoTask> tasks = new();

    private int nextId = 1;


    public List<TodoTask> GetTasks()
    {
        return tasks;
    }


    public void AddTask()
    {
        string title = AskForTitle();

        string project = AskForProject();

        DateTime dueDate = AskForDueDate();

        TodoTask newTask = new TodoTask(
            nextId,
            title,
            project,
            dueDate,
            false);

        tasks.Add(newTask);

        nextId++;

        Console.WriteLine("Task added successfully!");
    }


    private string AskForTitle()
    {
        Console.Write("Enter title: ");

        string input =
            Console.ReadLine()?.Trim() ?? "";

        return validate.ValidateTitle(input);
    }


    private string AskForProject()
    {
        Console.Write("Enter project: ");

        string input =
            Console.ReadLine()?.Trim() ?? "";

        return validate.ValidateProject(input);
    }


    private DateTime AskForDueDate()
    {
        Console.Write("Enter due date (YYYY-MM-DD): ");

        string input =
            Console.ReadLine()?.Trim() ?? "";

        return validate.ValidateDueDate(input);
    }
}