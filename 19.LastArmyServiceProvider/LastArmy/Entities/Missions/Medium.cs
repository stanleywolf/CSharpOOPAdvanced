public class Medium : Mission
{
    private const double endurance = 50;
    private const double wearLevelDecrement = 50;
    private const string MissionName = "Capturing dangerous criminals";

    public override double EnduranceRequired => endurance;

    public override string Name => MissionName;
    public override double WearLevelDecrement => wearLevelDecrement;

    public Medium(double scoreToComplete) 
        : base(scoreToComplete)
    {
    }
}
