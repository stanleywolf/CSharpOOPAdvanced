using System;
using System.Collections.Generic;
using System.Text;

public class BookComparator:IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        int result = x.Title.CompareTo(y.Title);
        if (result == 0)
        {
            //booth decending order
            //result = y.Year.CompareTo(x.Year); 
            result = x.Year.CompareTo(y.Year) * -1;
        }
        return result;
    }
}