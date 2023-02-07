namespace DateModifier
{
    public class StartUp
    {
        static void Main()
        {
            string[] start = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] end = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            DateTime startDate = new DateTime(int.Parse(start[0]), int.Parse(start[1]), int.Parse(start[2]));
            DateTime endDate = new DateTime(int.Parse(end[0]), int.Parse(end[1]), int.Parse(end[2]));

            DateModifier dateModifier= new DateModifier();

            Console.WriteLine(dateModifier.GetDifference(startDate, endDate));
            
        }
    }
}