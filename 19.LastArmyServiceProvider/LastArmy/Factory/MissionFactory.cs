using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        var assembly = Assembly.GetCallingAssembly();

        var missionType = assembly
            .GetTypes()
            .SingleOrDefault(t => t.Name == difficultyLevel);

        if (missionType == null || !typeof(IMission).IsAssignableFrom(missionType))
        {
            throw new ArgumentException();
        }

        var ctorParams = new object[]
        {
             neededPoints
        };

        var mission = (IMission)Activator.CreateInstance(missionType, ctorParams);

        return mission;
    }
}
