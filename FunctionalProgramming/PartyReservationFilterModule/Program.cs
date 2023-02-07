



List<string> guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

List<string> filters = new();

string input = string.Empty;
while ((input = Console.ReadLine()) != "Print")
{
    string[] cmndArgs = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
    string cmnd = cmndArgs[0];
    string filter = cmndArgs[1] + ";" + cmndArgs[2];

    if (cmnd == "Add filter")
    {
        filters.Add(filter);
    }
    else if (cmnd == "Remove filter")
    {
        filters.Remove(filter);
    }
}

foreach (var filter in filters)
{
    var filterBy = filter.Split(";", StringSplitOptions.RemoveEmptyEntries);

    switch (filterBy[0])
    {
        case "Starts with":
            guests = guests.Where(f => !f.StartsWith(filterBy[1])).ToList();
            break;
        case "Ends with":
            guests = guests.Where(f => !f.EndsWith(filterBy[1])).ToList();
            break;
        case "Contains":
            guests = guests.Where(f => !f.Contains(filterBy[1])).ToList();
            break;
        case "Length":
            guests = guests.Where(f => f.Length != int.Parse(filterBy[1])).ToList();
            break;
    }
}

if (guests.Any())
{
    Console.WriteLine(string.Join(" ", guests));
}


