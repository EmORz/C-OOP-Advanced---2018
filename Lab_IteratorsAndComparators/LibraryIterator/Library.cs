﻿using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library: IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }
        public IEnumerator<Book> GetEnumerator()
        {
            this.books.Sort(new BookComparator());
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int index;

            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = books;
            }

            public Book Current => this.books[index];

            object IEnumerator.Current => this.Current;

            public void Dispose(){}

            public bool MoveNext()
            {
                return ++index < this.books.Count;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
