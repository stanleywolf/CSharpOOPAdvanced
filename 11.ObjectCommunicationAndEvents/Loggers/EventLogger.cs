using System;
using System.Collections.Generic;
using System.Text;

public class EventLogger:Logger
{
    public override void Handle(LogType logType, string massage)
    {
        switch (logType)
        {
            case LogType.EVENT:
                Console.WriteLine(logType.ToString() + ": " + massage);
                break;
        }
        this.PassSuccessor(logType, massage);
    }
}