using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SpeedRacing
{
    internal class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double traveledDistance;

        public Car() 
        {

        }
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TraveledDistance { get; set; }

        public static void Drive(Car car, double travelDistance) 
        {
            double fuelNeeded = car.FuelConsumptionPerKilometer * travelDistance;

            if (car.FuelAmount >= fuelNeeded)
            {
                car.FuelAmount -= fuelNeeded;
                car.TraveledDistance += travelDistance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");

            }
        }
    }
}
