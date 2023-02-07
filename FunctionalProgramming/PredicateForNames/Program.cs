

int n = int.Parse(Console.ReadLine());

List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

Predicate<string> lengthPredicate = name => name.Length <= n;

foreach (var name in names.Where(x=> lengthPredicate(x)))
{
    Console.WriteLine(name);
}