using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators= new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == null || renovator.Name == string.Empty ||
                renovator.Type == null || renovator.Type == string.Empty)
            {
                return $"Invalid renovator's information.";
            }
            else if (NeededRenovators == 0)
            {
                return $"Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return $"Invalid renovator's rate.";
            }
            else
            {
                NeededRenovators--;
                renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovatorToRemove = renovators.FirstOrDefault(x => x.Name == name);
            renovators.Remove(renovatorToRemove);
            return renovatorToRemove == null? false : true; 
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            return renovators.RemoveAll(x => x.Type == type);
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovatorToHire = renovators.FirstOrDefault(n=>n.Name == name);
            if (renovatorToHire != null)
            {
                renovators.FirstOrDefault(n => n.Name == name).Hired = true;
                return renovatorToHire;
            }
                return null;
        }
        public List<Renovator> PayRenovators(int days)
        {
            return renovators.Where(r => r.Days >= days).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var item in renovators.Where(r => r.Hired == false))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
