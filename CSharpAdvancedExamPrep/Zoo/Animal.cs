﻿namespace Zoo
{
    public class Animal
    {
        private string species;
        private string diet;
        private double weight;
        private double length;

        public Animal(string species, string diet, double weight, double length)
        {
            Species = species;
            Diet = diet;
            Weight = weight;
            Length = length;
        }

        public string Species { get; set; }
        public string Diet { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }


        public override string ToString()
        {
            return $"The {this.Species} is a {this.Diet} and weighs {this.Weight} kg.";
        }
    }
}
