using System.Runtime.CompilerServices;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string tiresString = string.Empty;

            Dictionary<int, Tire[]> tiresDict = new Dictionary<int, Tire[]>();
            int tiresIndex = 0;

            while ((tiresString = Console.ReadLine()) != "No more tires")
            {
                string[] tiresInput = tiresString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var tires = new Tire[4]
                {
                new Tire (int.Parse(tiresInput[0]), double.Parse(tiresInput[1])),
                new Tire (int.Parse(tiresInput[2]), double.Parse(tiresInput[3])),
                new Tire (int.Parse(tiresInput[4]), double.Parse(tiresInput[5])),
                new Tire (int.Parse(tiresInput[6]), double.Parse(tiresInput[7]))
                };

                tiresDict.Add(tiresIndex, tires);
                tiresIndex++;
            }


            string enginesString = string.Empty;

            Dictionary<int, Engine> enginesDict = new Dictionary<int, Engine>();
            int enginesIndex = 0;

            while ((enginesString = Console.ReadLine()) != "Engines done")
            {
                string[] enginesInput = enginesString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var engine = new Engine(int.Parse(enginesInput[0]), double.Parse(enginesInput[1]));


                enginesDict.Add(enginesIndex, engine);
                enginesIndex++;
            }


            List<Car> cars = new List<Car>();
            //{make} {model} {year} {fuelQuantity} {fuelConsumption} {engineIndex} {tiresIndex}
            string carString = string.Empty;
            while ((carString = Console.ReadLine()) != "Show special")
            {
                string[] carInput = carString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = new(carInput[0], carInput[1], int.Parse(carInput[2]), double.Parse(carInput[3]), double.Parse(carInput[4]));
                
                car.Engine = enginesDict[int.Parse(carInput[5])];
                car.Tires = tiresDict[int.Parse(carInput[6])];

                cars.Add(car);
            }

                foreach (var car in cars.Where(y => y.Year >= 2017 && y.Engine.HorsePower > 330 ))
                {
                    double tirePressure = car.Tires.Sum(x => x.Pressure);

                    if (tirePressure >= 9 && tirePressure <= 10)
                    {
                        car.Drive(20);
                    }

                    Console.WriteLine(
                        $"Make: {car.Make}{Environment.NewLine}" +
                        $"Model: {car.Model}{Environment.NewLine}" +
                        $"Year: {car.Year}{Environment.NewLine}" +
                        $"HorsePowers: {car.Engine.HorsePower}{Environment.NewLine}" +
                        $"FuelQuantity: {car.FuelQuantity}");
                }
        }
    }
}
