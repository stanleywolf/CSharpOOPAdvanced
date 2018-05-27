using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OverallSkillMiltiplier = 2.5;
    private const int RegenerationLevel = 10;

    private readonly List<string> weaponsAllowed = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
        "Helmet",
        "Knife",
    };

    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;
    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;
    public override void Regenerate() => this.Endurance += (RegenerationLevel + this.Age);

}
