using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    private const string Suffix = "Harvester";
    public IHarvester GenerateHarvester(IList<string> args)
    {
        string type = args[0];

        int id = int.Parse(args[1]);
        double oreOutput = double.Parse(args[2]);
        double energyReq = double.Parse(args[3]);

        Type harvesterType = Assembly.GetCallingAssembly()
            .GetTypes()
            .SingleOrDefault(t => t.Name == type + Suffix);

        if (harvesterType == null || !typeof(IEntity).IsAssignableFrom(harvesterType))
        {
            throw new ArgumentException();
        }

        object[] ctorArgs = new object[]
        {
            id, oreOutput, energyReq
        };

        IHarvester harvester = (IHarvester)Activator.CreateInstance(harvesterType, ctorArgs);

        return harvester;
    }
}