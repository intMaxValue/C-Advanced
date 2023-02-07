int n = int.Parse(Console.ReadLine());

string text = string.Empty;
Stack<string> stack = new Stack<string>();

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split();

    string cmnd = input[0];
    

    if (cmnd == "1")
    {
        stack.Push(text);
        string parameters = input[1];
        text += parameters;
    }
    else if (cmnd == "2")
    {
        stack.Push(text);
        int count = int.Parse(input[1]);
        text = text.Remove(text.Length - count);
    }
    else if (cmnd == "3")
    {
        int index = int.Parse(input[1]);
        Console.WriteLine(text[index - 1]);
    }
    else if (cmnd == "4")
    {
        text = stack.Pop();
    }
}