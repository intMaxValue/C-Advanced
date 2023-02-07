

int[] bounds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int startNum = bounds[0];
int endNum = bounds[1];

List<int> result = new List<int>();
for (int i = startNum; i <= endNum; i++)
{
	result.Add(i);
}

string cmnd = Console.ReadLine();

Predicate<int> odd = num => num % 2 != 0;
Predicate<int> even = num => num % 2 == 0;

if (cmnd == "odd")
{
	foreach (var item in result.Where(x => odd(x)))
	{
		Console.Write(item + " "); 
	}
}
else if (cmnd == "even")
{
    foreach (var item in result.Where(x => even(x)))
    {
        Console.Write(item + " ");
    }
}

