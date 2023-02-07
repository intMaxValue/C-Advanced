using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    internal class Family
    {
        private List<Person> persons;

        public Family()
        {
            persons = new List<Person>();
        }

        public void AddMember(Person person)
        {
            persons.Add(person);
        }

        public Person GetOldestMember()
        {
            Person oldest = new Person();

            oldest = persons.MaxBy(p => p.Age);
            return oldest;
        }
    }
}
