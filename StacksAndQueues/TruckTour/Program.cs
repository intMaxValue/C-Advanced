int n = int.Parse(Console.ReadLine());

Queue<int[]> pumps = new Queue<int[]>();

for (int i = 0; i < n; i++)
{
    int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

    pumps.Enqueue(input);
}

int counter = 0;

while (true)
{
    int currPetrol = 0;
    bool isFound = true;

    for (int i = 0; i < n; i++)
    {

        int[] currPump = pumps.Dequeue();
        currPetrol += currPump[0];
        int distance = currPump[1];

        if (currPetrol < distance)
        {
            isFound = false;

        }

        currPetrol -= distance;
        pumps.Enqueue(currPump);
    }

    if (isFound)
    {
        break;
    }
    counter++;

    pumps.Enqueue(pumps.Dequeue());
}

Console.WriteLine(counter);