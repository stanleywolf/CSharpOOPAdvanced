using System;
using Microsoft.Extensions.DependencyInjection;

public class LastArmyMain
{
    public static void Main()
    {
        var serviseProvider = ConfigureServices();
        var gameController = serviseProvider.GetService<IGameController>();

        IRunnable engine = new Engine(gameController, new ConsoleReader(), new ConsoleWriter());
        engine.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<IAmmunitionFactory, AmmunitionFactory>();
        services.AddSingleton<ICommandParser, CommandParser>();
        services.AddSingleton<IMissionFactory, MissionFactory>();
        services.AddSingleton<ISoldierFactory, SoldierFactory>();
        services.AddSingleton<IWareHouse, WareHouse>();
        services.AddSingleton<IArmy, Army>();
        services.AddSingleton<IMissionController, MissionController>();
        services.AddSingleton<IGameController, GameController>();
        services.AddSingleton<IWareHouse, WareHouse>();

        IServiceProvider serviceProvider = services.BuildServiceProvider();

        return serviceProvider;
    }
}
