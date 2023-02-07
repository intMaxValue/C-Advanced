namespace CarSalesman
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<Car, Engine> carDict = new();

            Dictionary<string, Engine> engines = new();

            for (int i = 0; i < n; i++)
            {
                string[] engineInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string engineModel = engineInput[0];
                int enginePower = int.Parse(engineInput[1]);

                int engineDisplacement = 0;
                string engineEfficiency = "n/a";
                
                if (engineInput.Length == 3)
                {
                    bool isDisplacement = int.TryParse(engineInput[2], out engineDisplacement);

                    if (isDisplacement)
                    {
                        engineDisplacement = int.Parse(engineInput[2]);
                    }
                    else
                    {
                        engineEfficiency = engineInput[2];
                    }
                }

                if (engineInput.Length == 4)
                {
                    engineDisplacement = int.Parse(engineInput[2]);
                    engineEfficiency = engineInput[3];
                }

                Engine engine = new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency);
                engines.Add(engineModel, engine);
            }

            int m = int.Parse(Console.ReadLine());

            //Dictionary<string, Car> cars = new();

            for (int i = 0; i < m; i++)
            {
                string[] carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = carInput[0];
                string carEngine = carInput[1];

                int carWeight = 0;
                string carColor = "n/a";


                if (carInput.Length == 3)
                {
                    bool isWeight = int.TryParse(carInput[2], out carWeight);

                    if (isWeight)
                    {
                        carWeight = int.Parse(carInput[2]);
                    }
                    else
                    {
                        carColor = carInput[2];
                    }
                }

                if (carInput.Length == 4)
                {
                    carWeight = int.Parse(carInput[2]);
                    carColor = carInput[3];
                }

                Car car = new Car(carModel, engines[carEngine], carWeight, carColor);
                carDict.Add(car, engines[carEngine]);
            }

            foreach (var car in carDict)
            {
                Console.WriteLine($"{car.Key.Model}:");
                Console.WriteLine($"  {car.Value.Model}:");
                Console.WriteLine($"    Power: {car.Value.Power}");
                Console.WriteLine($"    Displacement: {(car.Value.Displacement == 0 ? "n/a" : car.Value.Displacement)}");
                Console.WriteLine($"    Efficiency: {car.Value.Efficiency}");
                Console.WriteLine($"  Weight: {(car.Key.Weight == 0 ? "n/a" : car.Key.Weight)}");
                Console.WriteLine($"  Color: {car.Key.Color}");
            }
        }
    }
}