using System;
using System.Collections.Generic;
using System.Text;

public class AppenderFactory
{
    private const string DEFAULT_FILE_NAME = "logFile{0}.txt";

    private LayoutFactory layoutFactory;
    private int fileNumber;

    public AppenderFactory(LayoutFactory layoutFactory)
    {
        this.layoutFactory = layoutFactory;
        this.fileNumber = 0;
    }

    public IAppender CreateAppender(string appenderType, string levelString, string layoutType)
    {
        ILayout layout= this.layoutFactory.CreateFactory(layoutType);
        ErrorLevel errorLevel = this.ParseErrorLevel(levelString);

        IAppender appender = null;
        switch (appenderType)
        {
            case "ConsoleAppender":
                appender = new ConsoleAppender(layout,errorLevel);
                break;
            case "FileAppender":
                ILogFile logFile = new LogFile(string.Format(DEFAULT_FILE_NAME, this.fileNumber));
                appender = new FileAppender(layout, errorLevel, logFile);
                break;
            default:
                    throw new ArgumentException("Invalid Appender Type");
        }
        return appender;
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
