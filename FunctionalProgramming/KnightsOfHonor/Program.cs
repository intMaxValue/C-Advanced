


string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string> action = name => Console.WriteLine($"Sir " + name);

foreach (var name in names)
{
    action(name);
}