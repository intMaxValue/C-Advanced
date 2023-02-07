﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuple
{
    public class Tuple<T1, T2>
    {
        public Tuple(T1 item1, T2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new();
            
            sb.AppendLine($"{Item1} -> {Item2}");
            
            return sb.ToString().Trim();
        }
    }
}
