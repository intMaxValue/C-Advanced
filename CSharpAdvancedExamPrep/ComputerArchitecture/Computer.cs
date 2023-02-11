using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor;
        private string model;
        private int capacity;

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        List<CPU> Multiprocessor 
        {
            get { return multiprocessor; }
            set { multiprocessor = value; }
        }

        public string Model 
        {
            get { return model; }
            set { model = value; } 
        }
        public int Capacity 
        { 
            get { return capacity; }
            set { capacity = value; }
        }

        public int Count { get => Multiprocessor.Count; }

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            CPU brandToRemove = Multiprocessor.FirstOrDefault(b => b.Brand == brand);

            if (brandToRemove != null)
            {
                Multiprocessor.Remove(brandToRemove);
                return true;
            }
            return false;
        }

        public CPU MostPowerful()
        {
            CPU mostPowerful = Multiprocessor.MaxBy(c => c.Frequency);
            return mostPowerful;
        }

        public CPU GetCPU(string brand)
        {
            CPU getCPU = Multiprocessor.FirstOrDefault(c=>c.Brand == brand);
            if (getCPU != null)
            {
                return getCPU;
            }
            return null;
        }

        public string Report()
        {
            StringBuilder sb =new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var item in Multiprocessor)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
