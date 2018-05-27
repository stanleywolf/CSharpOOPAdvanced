using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        var assembly = Assembly.GetCallingAssembly();

        var ammoType = assembly
            .GetTypes()
            .SingleOrDefault(t => t.Name == ammunitionName);

        if (ammoType == null || !typeof(IAmmunition).IsAssignableFrom(ammoType))
        {
            throw new ArgumentException();
        }

        var ammo = (IAmmunition)Activator.CreateInstance(ammoType);

        return ammo;
    }
}
