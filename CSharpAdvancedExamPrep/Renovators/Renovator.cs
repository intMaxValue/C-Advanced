using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        private string name;
        private string type;
        private double rate;
        private int days;
        private bool hired;

        public Renovator(string name, string type, double rate, int days)
        {
            this.name = name;
            this.type = type;
            this.rate = rate;
            this.days = days;
        }

        public string Name { get => name; }
        public string Type { get => type; }
        public double Rate { get => rate; }
        public int Days { get => days; }
        public bool Hired { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {name}");
            sb.AppendLine($"--Specialty: {type}");
            sb.AppendLine($"--Rate per day: {rate} BGN");

            return sb.ToString().Trim();

        }
    }
}
