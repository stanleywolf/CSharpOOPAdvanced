using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {

        ILogger logger = InstalizeLogger();
        ErrorFactiory errorFactiory = new ErrorFactiory();
        Engine engine = new Engine(logger, errorFactiory);
        engine.Run();
    }

    static ILogger InstalizeLogger()
    {
        ICollection<IAppender> appenders = new List<IAppender>();
        LayoutFactory layoutFactory = new LayoutFactory();
        AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

        var nunberOfAppenders = int.Parse(Console.ReadLine());

        for (int i = 0; i < nunberOfAppenders; i++)
        {
            string[] args = Console.ReadLine().Split();
            string appenderType = args[0];
            string layoutType = args[1];
            string errorLevel = "INFO";

            if (args.Length == 3)
            {
                errorLevel = args[2];
            }
            IAppender appender = appenderFactory.CreateAppender(appenderType, errorLevel, layoutType);
            appenders.Add(appender);

        }
        ILogger logger = new Logger(appenders);
        return logger;
    }
}