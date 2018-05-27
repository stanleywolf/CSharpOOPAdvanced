using System.Linq;

public class SoldierRegenerateCommand : ICommand
{
    private IArmy army;

    public SoldierRegenerateCommand(IArmy army)
    {
        this.army = army;
    }

    public string Execute(string[] arguments)
    {
        if (arguments.Length != 1)
        {
            return string.Empty;
        }

        string soldierType = arguments[0];

        this.army.RegenerateTeam(soldierType);

        return string.Empty;
    }
}
