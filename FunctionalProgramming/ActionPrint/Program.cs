


List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

Action<string> print = name => Console.WriteLine(name);

names.ForEach(print);
