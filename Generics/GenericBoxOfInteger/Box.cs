using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBoxOfInteger
{
    internal class Box<T>
    {
        public List<T> List { get; set; }

        public Box()
        {
            List= new List<T>();
        }

        public void Add(T item)
        {
            List.Add(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (T item in List)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
