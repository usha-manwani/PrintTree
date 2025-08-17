class Program
{
	static void Main()
	{
		Console.WriteLine("Enter numbers separated by spaces (e.g. 1 2 3 4 5):");
		string? input = Console.ReadLine();
		if (!string.IsNullOrWhiteSpace(input))
		{
			try
			{
				int[] arr = Array.ConvertAll(input.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
				Console.WriteLine("\nPrinting binary tree from your input:");
				TreePrinter.Print(arr);
			}
			catch
			{
				Console.WriteLine("Invalid input. Please enter only numbers separated by spaces.");
			}
		}
		else
		{
			Console.WriteLine("No input provided.");
		}
	}
}
