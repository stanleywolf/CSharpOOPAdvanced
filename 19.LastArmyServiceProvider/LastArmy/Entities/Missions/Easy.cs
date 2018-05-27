public class Easy : Mission
{
    private const double endurance = 20;
    private const double wearLevelDecrement = 30;
    private const string MissionName = "Suppression of civil rebellion";
    public override double EnduranceRequired => endurance;

    public override string Name => MissionName;

    public override double WearLevelDecrement => wearLevelDecrement;

    public Easy(double scoreToComplete)
        : base(scoreToComplete)
    {
    }
}
