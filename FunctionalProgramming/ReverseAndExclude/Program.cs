

using System.Security.Cryptography.X509Certificates;

List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

int divider = int.Parse(Console.ReadLine());

Predicate<int> isDivisable = num => num % divider == 0;

Func<List<int>, List<int>> func = list =>
{
	List<int> result = new List<int>();

	foreach (var item in list.Where(x => !isDivisable(x)))
	{
		result.Add(item);
	}
	return result;
};

nums.Reverse();

Console.WriteLine(string.Join(" ",func(nums)));