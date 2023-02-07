
int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

HashSet<int> setN = new HashSet<int>();
HashSet<int> setM = new HashSet<int>();

for (int i = 0; i < sizes[0] ; i++)
{
    setN.Add(int.Parse(Console.ReadLine()));
}

for (int j = 0; j < sizes[1] ; j++)
{
    setM.Add(int.Parse(Console.ReadLine()));
}

Console.WriteLine(string.Join(" ", setN.Intersect(setM)));