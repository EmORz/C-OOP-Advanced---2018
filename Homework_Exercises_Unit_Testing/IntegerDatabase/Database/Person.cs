using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Person
    {
        public Person(long id, string name)
        {
           this.Id = id;
           this.Name = name;
        }

        public long Id { get; private set; }

        public string Name { get; private set; }
    }
}
