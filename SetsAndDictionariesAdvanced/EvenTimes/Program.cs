int n = int.Parse(Console.ReadLine());

Dictionary<int, int> numbers = new();

for (int i = 0; i < n; i++)
{
	int input = int.Parse(Console.ReadLine());

	if (!numbers.ContainsKey(input))
	{
		numbers.Add(input, 0);
	}
	numbers[input]++;
}

Console.WriteLine(numbers.Single(n => n.Value % 2 == 0).Key);