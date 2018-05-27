using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private Dictionary<string, int> ammoCount = new Dictionary<string, int>()
    {
        { "Gun", 0},
        {"AutomaticMachine", 0},
        {"MachineGun", 0},
        {"RPG", 0},
        {"Helmet" , 0},
        {"Knife", 0},
        {"NightVision", 0}
    };

    private IAmmunitionFactory ammunitionFactory;

    
    public WareHouse(IAmmunitionFactory ammunitionFactory)
    {
        this.ammunitionFactory = ammunitionFactory;
    }

    public void AddAmmo(string ammoName, int count)
    {
        if (this.ammoCount.ContainsKey(ammoName))
        {
            this.ammoCount[ammoName] += count;
        }
    }
    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army)
        {
            this.EquipSoldier(soldier);
        }
    }

    public void EquipSoldier(ISoldier soldier)
    {
        var wornOutWeapos = soldier.Weapons
            .Where(w => w.Value == null)
            .ToArray();
            

        foreach (var weapon in wornOutWeapos)
        {
            if (this.ammoCount.ContainsKey(weapon.Key) && this.ammoCount[weapon.Key] > 0)
            {
                soldier.Weapons[weapon.Key] = this.ammunitionFactory.CreateAmmunition(weapon.Key);
                this.ammoCount[weapon.Key] = Math.Max(this.ammoCount[weapon.Key] - 1, 0);
            }
        }
    }
}
