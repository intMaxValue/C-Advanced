

List<int> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

string input;
while ((input = Console.ReadLine()) != "end")
{
	if (input == "add")
	{
		Func<List<int>, List<int>> func = list =>
		{
			for (int i = 0; i < list.Count; i++)
			{
				list[i]++;
			}
			return list;
		};
        list = func(list);
	}
	else if (input == "multiply")
	{
        Func<List<int>, List<int>> func = list =>
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i]*= 2;
            }
            return list;
        };
        list = func(list);

    }
    else if (input == "subtract")
    {
        Func<List<int>, List<int>> func = list =>
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i]--;
            }
            return list;
        };
        list = func(list);

    }
    else if (input == "print")
    {
        Console.WriteLine(string.Join(" ", list));
    }
}