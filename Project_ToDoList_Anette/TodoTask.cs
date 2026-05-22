public class TodoTask
{
    public int Id { get; set; }

    public string Title { get; set; } = "";

    public string Project { get; set; } = "";

    public DateTime DueDate { get; set; }

    public bool IsDone { get; set; }

    public TodoTask()
    {
    }

    public TodoTask(int id, string title, string project, DateTime dueDate, bool isDone)
    {
        Id = id;
        Title = title;
        Project = project;
        DueDate = dueDate;
        IsDone = isDone;
    }
}