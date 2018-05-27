using System;
using System.Collections.Generic;
using System.Text;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon CreateWeapon(string rarity, string weaponType,string name)
    {
        WeaponRarity weaponRarity = (WeaponRarity) Enum.Parse(typeof(WeaponRarity), rarity);
        Type classType = Type.GetType(weaponType);

        IWeapon instance = (IWeapon) Activator.CreateInstance(classType, new object[] {weaponRarity,name});

        return instance;
    }
}
  