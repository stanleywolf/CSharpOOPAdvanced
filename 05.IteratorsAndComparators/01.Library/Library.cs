using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        //return new LibraryEnumerator(books);
        for (int i = 0; i < this.books.Count; i++)
        {
            yield return books[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    private class LibraryEnumerator : IEnumerator<Book>
    {
        public Book Current => books[index];
        object IEnumerator.Current => this.Current;

        private IReadOnlyList<Book> books;
        private int index;

        public LibraryEnumerator(IReadOnlyList<Book> books)
        {
            this.books = books;
            this.index = -1;
        }

        public bool MoveNext()
        {
            index++;
            return index < books?.Count;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}