using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Library : IEnumerable<Book>
{
    private SortedSet<Book> books;

    public Library(params Book[] books)
    {
        this.books = new SortedSet<Book>(books,new BookComparator());
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books.ToList());
        //for (int i = 0; i < this.books.Count; i++)
        //{
        //    yield return books[i];
        //}
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    private class LibraryIterator : IEnumerator<Book>
    {
        public LibraryIterator(IReadOnlyList<Book> books)
        {
            this.Reset();
            this.books = books;
        }

        public Book Current => this.books[this.index];
        object IEnumerator.Current => this.Current;

        private IReadOnlyList<Book> books;
        private int index;

        public bool MoveNext()
        {
            index++;
            return index < books?.Count;
        }

        public void Reset() => this.index = -1;

        public void Dispose() { }
    }
}