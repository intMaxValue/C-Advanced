using System.Diagnostics.Metrics;

int green = int.Parse(Console.ReadLine());
int orange = int.Parse(Console.ReadLine());

Queue<string> queue = new();

int counter = 0;


string currCar = string.Empty;
string input;

while ((input = Console.ReadLine()) != "END")    // NOT FINISHED!!!
{
    
    if (input == "green")
    {
        while (true)
        {

        }
    }
    else if (input != "green")
    {
        queue.Enqueue(input);
    }
}

Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{counter} total cars passed the crossroads.");