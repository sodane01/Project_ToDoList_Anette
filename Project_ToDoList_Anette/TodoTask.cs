

// Represents a single task in the todo list application
public class TodoTask
{
    // Unique identifier for each task
    public int Id { get; set; }

    // Task title or description
    public string Title { get; set; } = "";

    // Project or category connected to the task
    public string Project { get; set; } = "";

    // Date when the task should be completed
    public DateTime DueDate { get; set; }

    // Indicates whether the task is completed
    public bool IsDone { get; set; }


    // Parameterless constructor required for file loading and object creation
    public TodoTask()
    {
    }


    // Creates a fully initialized task object
    public TodoTask(
        int id,
        string title,
        string project,
        DateTime dueDate,
        bool isDone)
    {
        Id = id;
        Title = title;
        Project = project;
        DueDate = dueDate;
        IsDone = isDone;
    }
}