using System;
using System.Collections.Generic;
using System.Text;

public interface IWeaponFactory
{
    IWeapon CreateWeapon(string rarity,string weaponType, string name);

}
