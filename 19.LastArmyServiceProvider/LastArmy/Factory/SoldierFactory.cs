using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        var assembly = Assembly.GetCallingAssembly();

        var soldierType = assembly
            .GetTypes()
            .SingleOrDefault(t => t.Name == soldierTypeName);

        if (soldierType == null || !typeof(ISoldier).IsAssignableFrom(soldierType))
        {
            throw new ArgumentException();
        }

        var ctorParams = new object[]
        {
            name, age, experience, endurance
        };

        var soldier = (ISoldier)Activator.CreateInstance(soldierType, ctorParams);

        return soldier;
    }
}
