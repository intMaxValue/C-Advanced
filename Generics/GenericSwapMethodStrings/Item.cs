using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSwapMethodStrings
{
    internal class Item<T>
    {
        public List<T> Items { get; set; }

        public Item()
        {
            Items = new List<T>();
        }

        public void Add(T item)
        {
            Items.Add(item);
        }

        public void Swap(int index1, int index2) 
        {
            (Items[index1], Items[index2]) = (Items[index2], Items[index1]);
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            foreach (T item in Items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString().Trim();
        }
    }
}
