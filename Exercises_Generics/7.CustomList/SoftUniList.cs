﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7.CustomList
{
    public class SoftUniList<T> : ISoftUniList<T>, IEnumerable<T>
        where T: IComparable<T>


    {
        private const int initialCapacity = 4;
        private T[] array;

        public int Count { get; private set; }

        public SoftUniList()
        {
            this.array = new T[initialCapacity];
            this.Count = 0;
        }

        public void Sort()
        {
            for (int i = 0; i < this.Count; i++)
            {
                for (int j = i+1; j < this.Count; j++)
                {
                    if (this.array[i].CompareTo(this.array[j])>0)
                    {
                        this.Exchange(i, j);
                    }
                }
            }
        }

        public void Add(T element)
        {
            if (this.array.Length==this.Count)
            {
                this.Resize();
            }
            this.array[Count++] = element;
        }

        private void Resize()
        {
            T[] tempArr = new T[this.array.Length*2];

            for (int i = 0; i < this.array.Length; i++)
            {
                tempArr[i] = array[i];
            }

            this.array = tempArr;
        }

        public T Remove(int index)
        {
            if (index<0 || index> this.Count)
            {
                throw new InvalidOperationException();
            }

            T element = this.array[index];
            this.array[index] = default(T);
            this.Count--;

            for (int i = index; i < this.Count; i++)
            {
                this.array[i] = this.array[i + 1];
            }

            if (this.array.Length!=this.Count)
            {
                this.array[this.Count] = default(T);
            }


            return element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(element))
                {
                    return true;
                }

            }
            return false;
        }

        public void Swap(int index1, int index2)
        {
            if (index1 < 0 || index1 >= this.Count && index2 < 0 || index2 >= this.Count)
            {
                throw new InvalidOperationException();
            }
            this.Exchange(index1, index2);
        }

        private void Exchange(int index1, int index2)
        {
            var temp = this.array[index1];
            this.array[index1] = this.array[index2];
            this.array[index2] = temp;
        }

        public int CountGreaterThan(T element)
        {
            var counter = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(element)>0)
                {
                    counter++;
                }
            }

            return counter;
        }

        public T Max()
        {
            if (this.Count ==0)
            {
                throw new InvalidOperationException();
            }

            T maxValue = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(maxValue)>0)
                {
                    maxValue = this.array[i];
                }
                
            }

            return maxValue;
        }

        public T Min()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T minValue = this.array[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.array[i].CompareTo(minValue) < 0)
                {
                    minValue = this.array[i];
                }

            }

            return minValue;
        }


 

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.array.Where(x => x != null));
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }


}
