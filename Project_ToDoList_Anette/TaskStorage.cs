public class TaskStorage
{
    private readonly string filePath = "tasks.csv";

    public List<TodoTask> LoadTasks()
    {
        List<TodoTask> tasks = new();

        if (!File.Exists(filePath))
        {
            return tasks;
        }

        var lines = File.ReadAllLines(filePath).Skip(1);

        foreach (var line in lines)
        {
            var parts = line.Split(',');

            int id = int.Parse(parts[0]);
            string title = parts[1];
            string project = parts[2];
            DateTime dueDate = DateTime.Parse(parts[3]);
            bool isDone = bool.Parse(parts[4]);

            tasks.Add(new TodoTask(id, title, project, dueDate, isDone));
        }

        return tasks;
    }

    public void SaveTasks(List<TodoTask> tasks)
    {
        using StreamWriter writer = new StreamWriter(filePath);

        writer.WriteLine("Id,Title,Project,DueDate,IsDone");

        foreach (var task in tasks)
        {
            writer.WriteLine($"{task.Id},{task.Title},{task.Project},{task.DueDate:yyyy-MM-dd},{task.IsDone}");
        }
    }
}