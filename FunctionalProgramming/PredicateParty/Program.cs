

List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

string input = string.Empty;
while ((input = Console.ReadLine()) != "Party!")
{
    string[] cmndArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string cmnd = cmndArgs[0];

    string[] tokens = cmndArgs.Skip(1).ToArray();

    if (cmnd == "Remove")
    {
        guests.RemoveAll(GetPredicate(tokens[0], tokens[1]));
    }
    else if (cmnd == "Double")
    {
        List<string> revised = guests.FindAll(GetPredicate(tokens[0], tokens[1]));

        if (revised.Any())
        {
            var indices = revised.FindIndex(GetPredicate(tokens[0], tokens[1]));

            guests.InsertRange(indices, revised);
        }
    }
}
    if (guests.Any())
    {
        Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
    }
    else
    {
        Console.WriteLine("Nobody is going to the party!");
    }

static Predicate<string> GetPredicate(string cmnd, string token)
{
    if (cmnd == "StartsWith")
    {
        return (name) => name.StartsWith(token);
    }
    else if (cmnd == "EndsWith")
    {
        return (name) => name.EndsWith(token);
    }
    else
    {
        return (name) => name.Length == (int.Parse(token));
    }
}