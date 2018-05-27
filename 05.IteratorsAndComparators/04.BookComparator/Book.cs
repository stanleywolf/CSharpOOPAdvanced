using System;
using System.Collections.Generic;
using System.Text;

public class Book:IComparable<Book>
{
    public string Title { get;private set; }
    public int Year { get; private set; }
    public IReadOnlyList<string> Authors { get; private set; }

    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = new List<string>(authors);
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }

    public int CompareTo(Book other)
    {
        var result = this.Year.CompareTo(other.Year);

        if (result == 0)
        {
            result = this.Title.CompareTo(other.Title);
        }
        return result;
    }
}