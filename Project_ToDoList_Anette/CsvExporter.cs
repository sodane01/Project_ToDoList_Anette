//public class CsvExporter : ITaskExporter
//{
//    public void Export(List<TodoTask> tasks, string filePath)
//    {
//        using StreamWriter writer = new StreamWriter(filePath);

//        writer.WriteLine("Id,Title,Project,DueDate,IsDone");

//        foreach (var task in tasks)
//        {
//            writer.WriteLine(
//                $"{task.Id}," +
//                $"{EscapeCsv(task.Title)}," +
//                $"{EscapeCsv(task.Project)}," +
//                $"{task.DueDate:yyyy-MM-dd}," +
//                $"{task.IsDone}");
//        }

//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.WriteLine("Tasks exported successfully!");
//        Console.ResetColor();

//        Console.WriteLine($"File saved to:");
//        Console.WriteLine(Path.GetFullPath(filePath));

//        Console.WriteLine();
//        Console.Write("Press Enter to return to menu...");
//        Console.ReadLine();
//    }

//    private string EscapeCsv(string value)
//    {
//        if (value.Contains(",") || value.Contains("\""))
//        {
//            value = value.Replace("\"", "\"\"");
//            return $"\"{value}\"";
//        }

//        return value;
//    }
//}
public class CsvExporter : ITaskExporter
{
    public void Export(List<TodoTask> tasks)
    {
        Console.Write(
            "Enter file name (example: tasks.csv): ");

        string input =
            Console.ReadLine()?.Trim() ?? "";

        string filePath =
            ValidateFileName(input);

        using StreamWriter writer =
            new StreamWriter(filePath);

        writer.WriteLine(
            "Id,Title,Project,DueDate,IsDone");

        foreach (var task in tasks)
        {
            writer.WriteLine(
                $"{task.Id}," +
                $"{EscapeCsv(task.Title)}," +
                $"{EscapeCsv(task.Project)}," +
                $"{task.DueDate:yyyy-MM-dd}," +
                $"{task.IsDone}");
        }

        Console.ForegroundColor =
            ConsoleColor.Green;

        Console.WriteLine(
            "Tasks exported successfully!");

        Console.ResetColor();

        Console.WriteLine("File saved to:");
        Console.WriteLine(
            Path.GetFullPath(filePath));
    }


    private string ValidateFileName(string input)
    {
        while (true)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "tasks.csv";
            }

            char[] invalidChars =
                Path.GetInvalidFileNameChars();

            if (input.Any(
                c => invalidChars.Contains(c)))
            {
                Console.WriteLine(
                    "File name contains invalid characters.");
            }
            else if (!input.EndsWith(
                ".csv",
                StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(
                    "File must end with .csv");
            }
            else
            {
                return input;
            }

            Console.Write(
                "Enter file name again: ");

            input =
                Console.ReadLine()?.Trim() ?? "";
        }
    }


    private string EscapeCsv(string value)
    {
        if (value.Contains(",") ||
            value.Contains("\""))
        {
            value =
                value.Replace("\"", "\"\"");

            return $"\"{value}\"";
        }

        return value;
    }
}
public interface ITaskExporter
{
    void Export(List<TodoTask> tasks);
}
//public interface ITaskExporter
//{
//    void Export(List<TodoTask> tasks, string filePath);
//}