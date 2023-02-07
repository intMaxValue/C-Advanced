

int n = int.Parse(Console.ReadLine());

List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

Console.WriteLine(FindName(CheckName, n, names));

static bool CheckName(string name, int n)
{
    int sum = name.ToCharArray().Sum(x => (int)x);
    return sum >= n;
}

static string FindName(Func<string, int, bool> checkName, int n, List<string> names)
{
    return names.FirstOrDefault(x => checkName(x, n));
}