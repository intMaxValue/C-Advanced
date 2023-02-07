using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    internal class DateModifier
    {
        private DateTime start;
        private DateTime end;

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string GetDifference(DateTime start, DateTime end)
        {
            var result = Math.Abs((start - end).Days);


            return result.ToString();
        }
    }
}
