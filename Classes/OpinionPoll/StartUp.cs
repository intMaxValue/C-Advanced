namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new();
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputPeople = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(inputPeople[0], int.Parse(inputPeople[1]));

                people.Add(person);
            }

            foreach (var person in people.OrderBy(p => p.Name).Where(p => p.Age > 30))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

        }
    }
}