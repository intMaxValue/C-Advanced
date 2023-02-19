using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public List<Drone> Drones { get; set; }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) ||
                drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if (Count >= Capacity)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            Drone droneToRemove = Drones.FirstOrDefault(d => d.Name == name);
            if (droneToRemove != null)
            {
                Drones.Remove(droneToRemove);
                return true;
            }
            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            return Drones.RemoveAll(d => d.Brand == brand);
        }

        public Drone FlyDrone(string name)
        {
            Drone droneToRemove = Drones.FirstOrDefault(d => d.Name == name);
            if (droneToRemove != null)
            {
                droneToRemove.Available = false;
                return droneToRemove;
            }
            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flyDrones = Drones.Where(d => d.Range >= range).ToList();
            foreach (var drone in flyDrones)
            {
                drone.Available = false;
            }
            return flyDrones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var drone in Drones.Where(d => d.Available == true))
            {
                sb.AppendLine(drone.ToString());
            }
                
            return sb.ToString().Trim();
        }
    }
}
