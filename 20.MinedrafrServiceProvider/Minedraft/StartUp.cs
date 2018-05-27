using System;
using Microsoft.Extensions.DependencyInjection;

public class StartUp
{
    static void Main()
    {
        var serviseProvider = ConfigureServices();
        var interpreter = serviseProvider.GetService<ICommandInterpreter>();
        var writer = serviseProvider.GetService<IWriter>();
        var reader = serviseProvider.GetService<IReader>();

        IRunnable engine = new Engine(interpreter, writer, reader);
        engine.Run();
    }

    private static IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<IEnergyRepository, EnergyRepository>();
        services.AddSingleton<IHarvesterController, HarvesterController>();
        services.AddSingleton<IProviderController, ProviderController>();
        services.AddSingleton<ICommandInterpreter, CommandInterpreter>();

        services.AddTransient<IHarvesterFactory, HarvesterFactory>();

        services.AddSingleton<IWriter, ConsoleWriter>();
        services.AddSingleton<IReader, ConsoleReader>();

        IServiceProvider serviceProvider = services.BuildServiceProvider();

        return serviceProvider;
    }
}
