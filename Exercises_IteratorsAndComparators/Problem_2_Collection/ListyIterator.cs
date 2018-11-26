using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problem_2_Collection
{
    public class ListyIterator<T>:IEnumerable<T>
    {
        
        private List<T> elements;
        private int index;

        public ListyIterator(params T[] elements)
        {
            this.elements = new List<T>(elements);
            this.index = 0;
        }


        public bool Move()
        {
            if (index<elements.Count-1)
            {
                index++;
                return true;
            }
            return false;
        }

        public bool HashNext()
        {
            return index + 1 < elements.Count;
        }
        public void Print()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.elements[index]);
        }

        public void PrintAll()
        {
            StringBuilder sb = new StringBuilder();
            if (elements.Count==0)
            {
                throw  new InvalidOperationException("Invalid Operation!");
            }

            foreach (var element in elements)
            {
                sb.Append(" " + element);
            }
            Console.WriteLine(sb.ToString().Trim());
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
