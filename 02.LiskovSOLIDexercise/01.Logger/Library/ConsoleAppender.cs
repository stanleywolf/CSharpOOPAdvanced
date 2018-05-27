using System;
using System.Collections.Generic;
using System.Text;

public class ConsoleAppender:IAppender
{
    public ErrorLevel Level { get; }
    public ILayout Layout { get; }
    public int MessagesAppendet { get; private set; }

    public ConsoleAppender(ILayout layout, ErrorLevel level)
    {
        this.Layout = layout;
        this.Level = level;
        this.MessagesAppendet = 0;
    }
    public void Append(IError error)
    {
        var formatError = this.Layout.FormatError(error);
        Console.WriteLine(formatError);
        this.MessagesAppendet++;
    }

    public override string ToString()
    {
        string result =
            $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.MessagesAppendet}";
        return result;
    }
}