

HashSet<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();

Func<HashSet<int>, int> minFunc = num =>
{
    int minNum = int.MaxValue;

    foreach (var item in nums)
    {
        if (item < minNum)
        {
            minNum = item;
        }
    }
    return minNum;
};

Console.WriteLine(minFunc(nums));