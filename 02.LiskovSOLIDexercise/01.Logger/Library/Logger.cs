﻿using System.Collections.Generic;


public class Logger:ILogger
{
    private ICollection<IAppender> appenders;

    public Logger(ICollection<IAppender> appenders)
    {
        this.appenders = appenders;
    }

    public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>) this.appenders;

    public void Log(IError error)
    {
        foreach (IAppender appender in this.appenders)
        {
            if (appender.Level <= error.Level)
            {
                appender.Append(error);
            }
        }
    }
}