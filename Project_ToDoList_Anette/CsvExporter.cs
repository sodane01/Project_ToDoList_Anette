
public interface ITaskExporter
{
    void Export(List<TodoTask> tasks);
}


public class CsvExporter : ITaskExporter
{
    // Exports tasks to a CSV file
    public void Export(List<TodoTask> tasks)
    {
        Console.Write(
            "Enter file name (example: tasks.csv): ");

        string input =
            Console.ReadLine()?.Trim() ?? "";

        // Validate the entered file name before export
        string filePath =
            ValidateFileName(input);

        using StreamWriter writer =
            new StreamWriter(filePath);

        // Write CSV header row
        writer.WriteLine(
            "Id,Title,Project,DueDate,IsDone");

        foreach (var task in tasks)
        {
            // Write each task as a formatted CSV row
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

        // Display the full file location to the user
        Console.WriteLine("File saved to:");

        Console.WriteLine(
            Path.GetFullPath(filePath));
    }


    // Validates that the entered file name is valid and ends with .csv
    private string ValidateFileName(string input)
    {
        while (true)
        {
            // Use a default file name if the input is empty
            if (string.IsNullOrWhiteSpace(input))
            {
                return "tasks.csv";
            }

            // Get invalid Windows file name characters
            char[] invalidChars =
                Path.GetInvalidFileNameChars();

            // Check for invalid characters
            if (input.Any(
                c => invalidChars.Contains(c)))
            {
                Console.WriteLine(
                    "File name contains invalid characters.");
            }

            // Ensure the file extension is .csv
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


    // Escapes commas and quotation marks to prevent CSV formatting issues
    private string EscapeCsv(string value)
    {
        if (value.Contains(",") ||
            value.Contains("\""))
        {
            // Double quotation marks must be escaped in CSV format
            value =
                value.Replace("\"", "\"\"");

            return $"\"{value}\"";
        }

        return value;
    }
}