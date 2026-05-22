public class TaskValidator
{
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

            input = Console.ReadLine()?.Trim() ?? "";
        }
    }


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

            input = Console.ReadLine()?.Trim() ?? "";
        }
    }


    public DateTime ValidateDueDate(string input)
    {
        while (true)
        {
            if (DateTime.TryParse(input, out DateTime dueDate))
            {
                return dueDate;
            }

            Console.WriteLine("Invalid date format.");

            Console.Write("Enter due date again (YYYY-MM-DD): ");

            input = Console.ReadLine()?.Trim() ?? "";
        }
    }

    public int ValidateExistingId(
    string input,
    List<TodoTask> tasks)
    {
        while (true)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("ID cannot be empty.");
            }
            else if (!int.TryParse(input, out int id))
            {
                Console.WriteLine("Invalid ID format.");
            }
            else if (!tasks.Any(t => t.Id == id))
            {
                Console.WriteLine("No task found with that ID.");
            }
            else
            {
                return id;
            }

            Console.Write("Enter ID again: ");

            input = Console.ReadLine()?.Trim() ?? "";
        }
    }
}