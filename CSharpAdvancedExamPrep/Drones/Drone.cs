﻿using System.Text;

namespace Drones
{
    public class Drone
    {
        private string name;
        private string brand;
        private int range;
        private bool available;

        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
            available = true;
        }

        public string Name { get; set; }
        public string Brand { get; set; }
        public int Range { get; set; }
        public bool Available
        {
            get
            {
                return available;
            }
            set
            {
                available = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {this.Name}")
              .AppendLine($"Manufactured by: {this.Brand}")
              .AppendLine($"Range: {this.Range} kilometers");

            return sb.ToString().Trim();
        }
    }
}
