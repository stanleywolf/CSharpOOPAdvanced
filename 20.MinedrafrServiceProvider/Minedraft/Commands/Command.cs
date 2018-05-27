using System.Collections.Generic;

public abstract class Command : ICommand
{
    public IList<string> Arguments { get; protected set; }

    public abstract string Execute();
}
