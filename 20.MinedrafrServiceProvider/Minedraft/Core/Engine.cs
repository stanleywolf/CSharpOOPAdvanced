using System;
using System.Linq;

public class Engine : IRunnable
{
    private ICommandInterpreter commandInterpreter;
    private IWriter writer;
    private IReader reader;

    public Engine(ICommandInterpreter commandInterpreter, IWriter writer, IReader reader)
    {
        this.commandInterpreter = commandInterpreter;
        this.writer = writer;
        this.reader = reader;
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                var input = this.reader.ReadLine();
                var data = input.Split().ToList();

                this.writer.WriteLine(this.commandInterpreter.ProcessCommand(data));
            }
            catch (Exception ex)
            {
                this.writer.WriteLine(ex.Message);
            }
        }
    }
}
