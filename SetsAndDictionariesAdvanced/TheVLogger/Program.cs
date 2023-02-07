
using System.Linq;

Dictionary<string, List<string>> followers = new();
Dictionary<string, List<string>> following = new();

string input;

while ((input = Console.ReadLine()) != "Statistics")
{
    string[] action = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string name = action[0];

    if (action[1] == "joined")
    {
        if (!followers.ContainsKey(name))
        {
            followers.Add(name, new List<string>());
        }
        if (!following.ContainsKey(name))
        {
            following.Add(name, new List<string>());
        }
        if (followers.ContainsKey(name))
        {
            continue;
        }
    }
    else if (action[1] == "followed")
    {
        string followedWho = action[2];
        //ako nqma imenata v lista
        if (!followers.ContainsKey(name) || !followers.ContainsKey(followedWho))
        {
            continue;
        }
        //ako sledva sebe si
        if (name == followedWho)
        {
            continue;
        }
        //ako veche go sledva
        if (followers[name].Contains(followedWho))
        {
            continue;
        }

        followers[followedWho].Add(name);
        following[name].Add(followedWho);
    }
}

Console.WriteLine($"The V-Logger has a total of {followers.Keys.Count} vloggers in its logs.");
bool isFirst = true;
int count = 1;


Dictionary<string, List<string>> temp = following.OrderBy(x=>x.Value.Count).ToDictionary(x=>x.Key,x=>x.Value);


foreach (var item in followers.OrderByDescending(f => f.Value.Count))
{
    
    Console.WriteLine($"{count}. {item.Key}: {item.Value.Count} followers, {temp[item.Key].Count} following");
    count++;

    if (isFirst)
    {
        foreach (var follower in followers[item.Key].OrderBy(x => x))
        {
            Console.WriteLine($"* {follower}");
        }
        isFirst= false;
    }
}


