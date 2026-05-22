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
}