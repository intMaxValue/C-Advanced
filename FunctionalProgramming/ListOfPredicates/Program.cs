

using System.Linq;

int n = int.Parse(Console.ReadLine());

List<int> nums = new List<int>();

for (int i = 1; i <= n; i++)
{
    nums.Add(i);
}

HashSet<int> dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();

Func<List<int>, HashSet<int>, List<int>> func = (nums, dividers) =>
{
    List<int> list = new List<int>();
    
    foreach (var item in nums)
    {
        bool isDivisable = true;

        foreach (var divider in dividers)
        {
            Predicate<int> predicate = item => item % divider != 0;
            if (predicate(item))
            {
                isDivisable = false;
                break;
            }
        }
        if (isDivisable)
        {
            list.Add(item);
        }
    }

    return list;
};

Console.WriteLine(string.Join(" ",func(nums, dividers)));