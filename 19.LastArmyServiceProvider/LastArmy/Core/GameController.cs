using System;
using System.Linq;
using System.Text;

public class GameController : IGameController
{
    private IServiceProvider serviceProvider;

    private IArmy army;
    private IMissionController missionController;
    private ICommandParser commandFactory;
    private StringBuilder stringBuilder;

    public GameController(IServiceProvider serviceProvider, IMissionController missionController, ICommandParser commandFactory, IArmy army)
    {
        this.army = army;
        this.missionController = missionController;
        this.serviceProvider = serviceProvider;
        this.commandFactory = commandFactory;
        this.stringBuilder = new StringBuilder();
    }
    public void GiveInputToGameController(string input)
    {
        try
        {
            var args = input.Split();

            string comandName = args[0];
            args = args.Skip(1).ToArray();

            if (args[0] == "Regenerate")
            {
                comandName += args[0];
                args = args.Skip(1).ToArray();
            }

            var command = this.commandFactory.Parse(this.serviceProvider, comandName);

            string result = command.Execute(args);

            if (!string.IsNullOrWhiteSpace(result))
            {
                this.stringBuilder.AppendLine(result);
            }
        }
        catch (ArgumentException e)
        {
            this.stringBuilder.AppendLine(e.Message);
        }
    }

    public string RequestResult()
    {
        this.missionController.FailMissionsOnHold();

        this.stringBuilder.AppendLine(OutputMessages.Results);
        this.stringBuilder.AppendLine(OutputMessages.SuccessfulMissions + this.missionController.SuccessMissionCounter);
        this.stringBuilder.AppendLine(OutputMessages.FailedMissions + this.missionController.FailedMissionCounter);
        this.stringBuilder.AppendLine(OutputMessages.Soldiers);
        this.stringBuilder.AppendLine(string.Join(Environment.NewLine, this.army));

        return this.stringBuilder.ToString().Trim();
    }

}
