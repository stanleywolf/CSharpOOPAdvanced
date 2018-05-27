using System;

public class WareHouseCommand : ICommand
{
    private IWareHouse wareHouse;

    public WareHouseCommand(IWareHouse wareHouse)
    {
        this.wareHouse = wareHouse;
    }

    public string Execute(string[] arguments)
    {
        if (arguments.Length != 2)
        {
            return string.Empty;
        }

        string name = arguments[0];
        int count = int.Parse(arguments[1]);

        this.wareHouse.AddAmmo(name, count);

        return String.Empty;
    }
}
