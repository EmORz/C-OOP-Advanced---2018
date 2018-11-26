namespace Problem_1_ListyIterator
{
    using System;
    using System.Collections.Generic;

    public class ListyIterator<T>
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
            if (elements.Count==0)
            {
                throw  new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.elements[index]);
        }

    }
}
