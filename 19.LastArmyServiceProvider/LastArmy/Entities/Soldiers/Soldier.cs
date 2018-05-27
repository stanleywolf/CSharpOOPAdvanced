using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const double MaxEnduranceAllowed = 100;

    private double endurance;
    public string Name { get; }
    public int Age { get; }
    public double Experience { get; private set; }

    public double Endurance
    {
        get => this.endurance;
        protected set { this.endurance = Math.Min(value, MaxEnduranceAllowed); }
    }
    public virtual double OverallSkill => this.Age + this.Experience;
    public IDictionary<string, IAmmunition> Weapons { get; }
    
    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();

        foreach (var weaponKey in this.WeaponsAllowed)
        {
            this.Weapons[weaponKey] = null;
        }
    }
    public abstract void Regenerate();

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    public void CompleteMission(IMission mission)
    {
        if (this.Endurance >= mission.EnduranceRequired)
        {
            this.endurance -= mission.EnduranceRequired;

            this.AmmunitionRevision(mission.WearLevelDecrement);
            this.Experience += mission.EnduranceRequired;
        }
    }
    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        foreach (string weaponName in this.WeaponsAllowed)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public override string ToString() => $"{this.Name} - {this.OverallSkill}";
}