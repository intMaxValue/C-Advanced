using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;


        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }


        //public override string ToString()
        //{
        //    return $"{this.Model}: {Environment.NewLine}" +
        //        $" {this.Engine.Model}: {Environment.NewLine}" +
        //        $"  Power: {this.Engine.Power} {Environment.NewLine}" +
        //        $"  Discplacement: {this.Engine.Displacement} {Environment.NewLine}" +
        //        $"  Efficiency: {this.Engine.Efficiency} {Environment.NewLine}" +
        //        $"Weight: {this.Weight} {Environment.NewLine}" +
        //        $"Color: {this.Color}";
        //}
    }
}
