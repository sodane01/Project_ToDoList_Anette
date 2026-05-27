public class TaskValidator
{
    // Validates that the task title is not empty
    public string ValidateTitle(string input)
    {
        while (true)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            Console.WriteLine("Title cannot be empty.");

            Console.Write("Enter title again: ");

            input =
                Console.ReadLine()?.Trim() ?? "";
        }
    }


    // Validates that the project name is not empty
    public string ValidateProject(string input)
    {
        while (true)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            Console.WriteLine("Project cannot be empty.");

            Console.Write("Enter project again: ");

            input =
                Console.ReadLine()?.Trim() ?? "";
        }
    }


    // Validates that the entered date has a valid format
    public DateTime ValidateDueDate(string input)
    {
        while (true)
        {
            if (DateTime.TryParse(
                input,
                out DateTime dueDate))
            {
                return dueDate;
            }

            Console.WriteLine(
                "Invalid date format.");

            Console.Write(
                "Enter due date again (YYYY-MM-DD): ");

            input =
                Console.ReadLine()?.Trim() ?? "";
        }
    }


    // Validates that the entered task ID exists in the task list
    public int ValidateExistingId(
        string input,
        List<TodoTask> tasks)
    {
        while (true)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(
                    "ID cannot be empty.");
            }
            else if (!int.TryParse(
                input,
                out int id))
            {
                Console.WriteLine(
                    "Invalid ID format.");
            }
            else if (!tasks.Any(
                t => t.Id == id))
            {
                Console.WriteLine(
                    "No task found with that ID.");
            }
            else
            {
                return id;
            }

            Console.Write("Enter ID again: ");

            input =
                Console.ReadLine()?.Trim() ?? "";
        }
    }


    // Validates that the file name is safe and ends with .csv
    public string ValidateFileName(string input)
    {
        while (true)
        {
            // Use default file name if the user leaves the input empty
            if (string.IsNullOrWhiteSpace(input))
            {
                return "tasks.csv";
            }

            // Get all invalid characters for Windows file names
            char[] invalidChars =
                Path.GetInvalidFileNameChars();

            // Check for invalid characters
            if (input.Any(
                c => invalidChars.Contains(c)))
            {
                Console.WriteLine(
                    "File name contains invalid characters.");
            }

            // Ensure the file uses CSV format
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
}