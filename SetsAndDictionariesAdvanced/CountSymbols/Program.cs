
string input = Console.ReadLine();

SortedDictionary<char, int> text = new();

foreach (char ch in input)
{
	if (!text.ContainsKey(ch))
	{
		text.Add(ch, 0);
	}
	text[ch]++;
}

foreach (var item in text)
{
	Console.WriteLine($"{item.Key}: {item.Value} time/s");
}