using System;
using System.Collections.Generic;
using System.Text;

public interface ICommandInterpreter
{
    IExecutable InterpredCommand(string commandName, string[] data);
}