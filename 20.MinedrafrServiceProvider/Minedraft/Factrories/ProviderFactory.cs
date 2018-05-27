using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    private const string Suffix = "Provider";
    public IProvider GenerateProvider(IList<string> args)
    {
        string type = args[0];
        int id = int.Parse(args[1]);
        double energyOutput = double.Parse(args[2]);

        Type providerType = Assembly.GetCallingAssembly()
            .GetTypes()
            .SingleOrDefault(t => t.Name == type + Suffix);

        if (providerType == null || !typeof(IEntity).IsAssignableFrom(providerType))
        {
            throw new ArgumentException();
        }

        object[] ctorArgs = new object[]
        {
            id, energyOutput
        };

        IProvider provider = (IProvider)Activator.CreateInstance(providerType, ctorArgs);

        return provider;
    }
}