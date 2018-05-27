using System;
using System.Linq;
using System.Reflection;

public class CommandParser : ICommandParser
{
    private const string Suffix = "Command";
    public ICommand Parse(IServiceProvider serviceProvider, string commandName)
    {
        var commandType = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .SingleOrDefault(t => t.Name == commandName + Suffix);

        if (commandType == null || !typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new ArgumentException();
        }

        var ctorParams = commandType
            .GetConstructors()
            .First()
            .GetParameters();

        object[] args = new object[ctorParams.Length];

        for (int i = 0; i < args.Length; i++)
        {
            args[i] = serviceProvider.GetService(ctorParams[i].ParameterType);
        }

        var command = (ICommand)Activator.CreateInstance(commandType, args);

        return command;
    }
}
