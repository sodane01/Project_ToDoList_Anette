

public class TaskStorage
{
    // Default CSV file used for persistent task storage
    private readonly string filePath = "tasks.csv";


    // Loads tasks from the CSV file into a task list
    public List<TodoTask> LoadTasks()
    {
        List<TodoTask> tasks = new();

        // Return an empty list if the storage file does not exist
        if (!File.Exists(filePath))
        {
            return tasks;
        }

        // Skip the CSV header row
        var lines =
            File.ReadAllLines(filePath)
            .Skip(1);

        foreach (var line in lines)
        {
            // Split each CSV row into separate values
            var parts = line.Split(',');

            int id =
                int.Parse(parts[0]);

            string title =
                parts[1];

            string project =
                parts[2];

            DateTime dueDate =
                DateTime.Parse(parts[3]);

            bool isDone =
                bool.Parse(parts[4]);

            // Recreate TodoTask objects from CSV data
            tasks.Add(
                new TodoTask(
                    id,
                    title,
                    project,
                    dueDate,
                    isDone));
        }

        return tasks;
    }


    // Saves the current task list to the CSV file
    public void SaveTasks(List<TodoTask> tasks)
    {
        using StreamWriter writer =
            new StreamWriter(filePath);

        // Write CSV header row
        writer.WriteLine(
            "Id,Title,Project,DueDate,IsDone");

        foreach (var task in tasks)
        {
            // Write each task as a CSV row
            writer.WriteLine(
                $"{task.Id}," +
                $"{task.Title}," +
                $"{task.Project}," +
                $"{task.DueDate:yyyy-MM-dd}," +
                $"{task.IsDone}");
        }
    }
}