public interface IHarvesterController : IController
{
    double OreProduced { get; }

    string ChangeMode(string newMode);
}