using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class SimpleLayout:ILayout
{
    //date-level-message
    private const string DateFrmat = "M/d/yyyy h:mm:ss tt";
    private const string FORMAT = "{0} - {1} - {2}";

    public string FormatError(IError error)
    {
        string dateString = error.DateTime.ToString(DateFrmat, CultureInfo.InvariantCulture);
        string formatError = String.Format(FORMAT,dateString, error.Level.ToString(),error.Message);

        return formatError;
    }
}