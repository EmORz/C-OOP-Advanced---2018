using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem_3_Stack.Models
{
    public class Stack<T>: IEnumerable<T>
    {
        private List<T> elements;
        private int currentIndex;

        public Stack()
        {
            this.elements = new List<T>();
            this.currentIndex = -1;
        }

        public void Push(params T[] items)
        {
            foreach (var item in items)
            {
                this.elements.Insert(++currentIndex, item);
            }
        }

        public void Pop()
        {
            if (currentIndex<0)
            {
                throw  new Exception("No elements");
            }
            currentIndex--;
        }
        public IEnumerator<T> GetEnumerator()
        {

            for (int i = currentIndex; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
