using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseExtended
{
    public class Database
    {
        private Person[] database;
        private int index;

        public Database(params Person[] data)
        {
            if (data.Length>16)
            {
                throw new InvalidOperationException("Out of range");
            }
            this.database = new Person[16];
            this.index = 0;

            foreach (var person in data)
            {
                this.Add(person);
            }
        }

        public void Add(Person person)
        {
            if (index == 16)
            {
                throw new InvalidOperationException("Out of range");
            }
            if (this.database.Any(p => p!= null && p.Name == person.Name))
            {
                throw new InvalidOperationException("Out of range");
            }
            if (this.database.Any(p => p != null && p.Id == person.Id))
            {
                throw new InvalidOperationException("Out of range");
            }
            this.database[index++] = person;
        }

        public Person Remove()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

           return this.database[--index];
        }

        public Person FindByUsername(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }
            if (!this.database.Any(p => p != null && p.Name == name))
            {
                throw new InvalidOperationException("");
            }

            return this.database.Single(p => p != null && p.Name == name);
        }

        public Person FindById(long id)
        {
            if (id<0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (!this.database.Any(p => p != null && p.Id == id))
            {
                throw new InvalidOperationException("");
            }

            return this.database.Single(p => p != null && p.Id == id);
        }

        public Person[] Fetch()
        {
            return this.database.Take(index).ToArray();
        }
    }
}
