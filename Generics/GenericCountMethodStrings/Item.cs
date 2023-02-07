using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodStrings
{
    internal class Item<T> where T : IComparable<T>
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

        public int Compare(T input)
        {
            int count = 0;

            foreach (var item in Items)
            {
                if (item.CompareTo(input) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
