using System;
using System.Collections.Generic;
using System.Text;


public interface ILogger
{
    IReadOnlyCollection<IAppender> Appenders { get; }

    void Log(IError error);

}

