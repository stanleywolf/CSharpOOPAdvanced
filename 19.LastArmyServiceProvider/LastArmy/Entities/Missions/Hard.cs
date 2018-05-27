public class Hard : Mission
{
    private const double endurance = 80;
    private const double wearLevelDecrement = 70;
    private const string MissionName = "Disposal of terrorists";

    public override double EnduranceRequired => endurance;

    public override string Name => MissionName;
    public override double WearLevelDecrement => wearLevelDecrement;

    public Hard(double scoreToComplete)
        : base(scoreToComplete)
    {
    }
}
