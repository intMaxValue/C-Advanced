using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SpeedRacing
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

                Car car = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]));

                cars.Add(car);
            }

            string secondInput = string.Empty;
            while ((secondInput = Console.ReadLine()) != "End")
            {
                string[] driveInput = secondInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var currCar = cars.First(c => c.Model == $"{driveInput[1]}");
                cars.IndexOf(currCar);

                Car.Drive(currCar, double.Parse(driveInput[2]));
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TraveledDistance}");
            }
        }
    }
}