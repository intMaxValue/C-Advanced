namespace RawData
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                
                Engine engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));

                Cargo cargo = new Cargo(input[4], int.Parse(input[3]));

                Tire[] tires = new Tire[4];
                {
                    tires[0] = new Tire(int.Parse(input[6]), double.Parse(input[5]));
                    tires[1] = new Tire(int.Parse(input[8]), double.Parse(input[7]));
                    tires[2] = new Tire(int.Parse(input[10]), double.Parse(input[9]));
                    tires[3] = new Tire(int.Parse(input[12]), double.Parse(input[11]));
                };

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string cmnd = Console.ReadLine();

            if (cmnd == "fragile")
            {
                foreach (var car in cars.Where(c=>c.Cargo.Type == "fragile" && c.Tires.Any(t=> t.Pressure < 1)))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else if (cmnd == "flammable")
            {
                foreach (var car in cars.Where(c=>c.Cargo.Type == "flammable" && c.Engine.Power > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }
    }
}