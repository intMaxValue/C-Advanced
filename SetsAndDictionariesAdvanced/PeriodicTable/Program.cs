
int n = int.Parse(Console.ReadLine());  

SortedSet<string> elements = new();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int j = 0; j < input.Length; j++)
    {
        elements.Add(input[j]);
    }
}

Console.WriteLine(string.Join(" ", elements)) ;