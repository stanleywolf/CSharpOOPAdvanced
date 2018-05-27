using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

public class ErrorFactiory
{
    const string FORMAT = "M/d/yyyy h:mm:ss tt";

    public IError CreatError(string dateTymeString, string errorLevelString, string message)
    {
        DateTime dateTime = DateTime.ParseExact(dateTymeString, FORMAT,CultureInfo.InvariantCulture);
        ErrorLevel errorLevel = ParseErrorLevel(errorLevelString);

        IError error = new Error(dateTime,errorLevel,message);

        return error;
    }
    private ErrorLevel ParseErrorLevel(string levelString)
    {
        try
        {
            object levelObj = Enum.Parse(typeof(ErrorLevel), levelString);

            return (ErrorLevel)levelObj;
        }
        catch (ArgumentException e)
        {
            throw new ArgumentException("Invalid ErrorLevel Type!!!");
        }

    }
}