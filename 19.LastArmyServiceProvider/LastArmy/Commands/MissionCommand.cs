public class MissionCommand : ICommand
{
    private IMissionFactory missionFactory;
    private IMissionController missionController;

    public MissionCommand(IMissionFactory missionFactory, IMissionController missionController)
    {
        this.missionFactory = missionFactory;
        this.missionController = missionController;
    }

    public string Execute(string[] arguments)
    {
        if (arguments.Length != 2)
        {
            return string.Empty;
        }

        string missionType = arguments[0];
        double scoreToComplete = double.Parse(arguments[1]);

        var mission = this.missionFactory.CreateMission(missionType, scoreToComplete);

        string result = this.missionController.PerformMission(mission);

        return result;
    }
}
