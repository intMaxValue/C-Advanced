using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model)
        {
            this.Model = model;
        }
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = 0;
            this.efficiency = "n/a"; 
        }
        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
        {

            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; } 
        public string Efficiency { get; set; }
    }
}
