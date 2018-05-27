using System;
using System.Linq;

public class SoldierCommand : ICommand
{
    private IArmy army;
    private IWareHouse wareHouse;
    private ISoldierFactory soldierFactory;
    private IAmmunitionFactory ammunitionFactory;

    public SoldierCommand(IArmy army, IWareHouse wareHouse, ISoldierFactory soldierFactory, IAmmunitionFactory ammunitionFactory)
    {
        this.army = army;
        this.wareHouse = wareHouse;
        this.soldierFactory = soldierFactory;
        this.ammunitionFactory = ammunitionFactory;
    }

    public string Execute(string[] arguments)
    {
        if (arguments.Length != 5)
        {
            return String.Empty;
        }

        string soldierType = arguments[0];
        string name = arguments[1];
        int age = int.Parse(arguments[2]);
        double experience = double.Parse(arguments[3]);
        double endurance = double.Parse(arguments[4]);

        var soldier = (Soldier)this.soldierFactory.CreateSoldier(soldierType, name, age, experience, endurance);

        this.wareHouse.EquipSoldier(soldier);

        if (soldier.Weapons.All(w => w.Value != null))
        {
            this.army.AddSoldier(soldier);
            return string.Empty;
        }

        throw new ArgumentException(string.Format(OutputMessages.NotEnoughtWeapons, soldierType, name));
    }
}
