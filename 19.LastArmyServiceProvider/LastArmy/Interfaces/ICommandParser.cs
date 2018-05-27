using System;

public interface ICommandParser
{
    ICommand Parse(IServiceProvider serviceProvider, string commandName);
}
