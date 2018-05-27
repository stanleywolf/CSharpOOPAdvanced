using System;
using System.Collections.Generic;
using System.Text;

public class FileAppender:IAppender
{
    public ErrorLevel Level { get; }
    public ILayout Layout { get; }
    public ILogFile LogFile { get; }

    public int MessagesAppendet { get; private set; }

    public FileAppender(ILayout layout, ErrorLevel level, ILogFile logFile)
    {
        this.Layout = layout;
        this.Level = level;
        this.LogFile = logFile;
        this.MessagesAppendet = 0;
    }
    public void Append(IError error)
    {
        string formatedError = this.Layout.FormatError(error);
        this.LogFile.WriteToFile(formatedError);
        this.MessagesAppendet++;
    }
    public override string ToString()
    {
        string result =
            $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.MessagesAppendet}, File size: {this.LogFile.Size}";
        return result;
    }
}