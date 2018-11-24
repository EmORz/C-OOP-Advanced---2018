using System;
using System.Collections.Generic;

namespace _7.CustomList
{
    public interface ISoftUniList<T>: IEnumerable<T>
    {
        int Count { get; }

        void Sort();

        void Add(T element);

        T Remove(int index);

        bool Contains(T element);

        void Swap(int index1, int index2);

        int CountGreaterThan(T element);

        T Max();

        T Min();

    }
}
