using System;
using System.Collections.Generic;
using System.Text;

public class CombatLogger:Logger
{
    public override void Handle(LogType logType, string massage)
    {
        switch (logType)
        {
            case LogType.ATTACK:
                Console.WriteLine(logType.ToString() + ": "+ massage);
                break;
            case LogType.MAGIC:
                Console.WriteLine(logType.ToString() + ": " + massage);
                break;
        }
        this.PassSuccessor(logType, massage);
    }
}