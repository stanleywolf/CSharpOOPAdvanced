using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private ILogger logger;
    private ErrorFactiory errorFactiory;
    public Engine(ILogger logger, ErrorFactiory errorFactiory)
    {
        this.logger = logger;
        this.errorFactiory = errorFactiory;
    }

    public void Run()
    {
        string input;
        while ((input = Console.ReadLine())!= "END")
        {
            string[] errorArgs = input.Split('|');
            string level = errorArgs[0];
            string dateTime = errorArgs[1];
            string message = errorArgs[2];

            IError error = errorFactiory.CreatError(dateTime, level, message);

            this.logger.Log(error);
        }
        Console.WriteLine("Logger info");
        foreach (IAppender appender in this.logger.Appenders)
        {
            Console.Write(appender);
        }
    }
}