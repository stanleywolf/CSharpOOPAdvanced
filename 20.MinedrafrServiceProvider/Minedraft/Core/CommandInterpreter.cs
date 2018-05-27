using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string Suffix = "Command";
    public IHarvesterController HarvesterController { get; }
    public IProviderController ProviderController { get; }

    private IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public string ProcessCommand(IList<string> args)
    {
        ICommand command = this.CreateCommand(args);

        return command.Execute();
    }

    private ICommand CreateCommand(IList<string> args)
    {
        string commandName = args[0].Trim();

        IList<string> commandArgs =  args.Skip(1).ToList();

        Type commandType = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == commandName + Suffix);

        if (commandType == null || !typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new ArgumentException();
        }

        var ctorParams = commandType
            .GetConstructors(BindingFlags.Instance | BindingFlags.Public)
            .Select(c => c.GetParameters())
            .First();

        var ctorArgs = new object[ctorParams.Length];

        for (int i = 0; i < ctorParams.Length; i++)
        {
            if (typeof(IList<string>).IsAssignableFrom(ctorParams[i].ParameterType))
            {
                ctorArgs[i] = commandArgs;
                continue;
            }
            
            ctorArgs[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
        }

        ICommand command = (ICommand)Activator.CreateInstance(commandType, ctorArgs);
        return command;
    }
}
