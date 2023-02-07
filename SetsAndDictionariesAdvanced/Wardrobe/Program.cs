
int n = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, int>> wardrobe = new();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries).ToArray();

    string color = input[0];

    if (!wardrobe.ContainsKey(color))
    {
        wardrobe.Add(color, new Dictionary<string, int>());
    }

    for (int j = 1; j < input.Length; j++)
    {
        if (!wardrobe[color].ContainsKey(input[j]))
        {
            wardrobe[color].Add(input[j], 0);
        }
        wardrobe[color][input[j]]++;
    }
}

string[] lookFor = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

string colorToLookFor = lookFor[0];
string itemToLookFor = lookFor[1];

foreach (var color in wardrobe)
{
    Console.WriteLine($"{color.Key} clothes:");

    foreach (var cloth in color.Value)
    {
        if (cloth.Key == itemToLookFor && color.Key == colorToLookFor)
        {
            Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
            continue;
        }

        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
    }
}