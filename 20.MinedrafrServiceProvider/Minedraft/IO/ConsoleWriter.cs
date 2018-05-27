using System;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);

        if (message.Contains("System Shutdown"))
        {
            Environment.Exit(0);
        }
    }
}
