using System;
using System.Linq;
using System.Reflection;
using Travel.Entities.Airplanes;

namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;

	public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
		    Type airplaneType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(c => c.Name == type);
		    return (IAirplane) Activator.CreateInstance(airplaneType);

			//switch (type)
			//{
			//	case "LightAirplane":
			//		return new LightAirplane();
			//	case "MediumAirplane":
			//		return new MediumAirplane();
			//	default:
   //                 throw new InvalidOperationException($"{type} of airplane is invalid");
			//}
		}
	}
}