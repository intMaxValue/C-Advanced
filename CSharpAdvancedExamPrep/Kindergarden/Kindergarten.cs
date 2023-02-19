using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public List<Child> Registry { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int ChildrenCount => Registry.Count;

        public bool AddChild(Child child)
        {
            if (Registry.Count >= Capacity)
            {
                return false;
            }
            Registry.Add(child);
            return true;
        }

        public bool RemoveChild(string childFullName)
        {
            string[] name = childFullName.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string firstN = name[0];
            string lastN = name[1];

            Child childToRemove = Registry.FirstOrDefault(n => n.FirstName == firstN && n.LastName == lastN);

            if (childToRemove != null)
            {
                Registry.Remove(childToRemove);
                return true;
            }
            return false;
        }

        public Child GetChild(string childFullName)
        {
            string[] name = childFullName.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string firstN = name[0];
            string lastN = name[1];

            Child child = Registry.FirstOrDefault(n => n.FirstName == firstN && n.LastName == lastN);
            if (child != null)
            {
                return child;
            }
            return null;
        }

        public string RegistryReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Registered children in {Name}:");
            foreach (var child in Registry.OrderByDescending(c=> c.Age).ThenBy(c=>c.LastName).ThenBy(c=>c.FirstName))
            {
                sb.AppendLine(child.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
