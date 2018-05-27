using System;
using System.Linq;
using System.Reflection;
using Travel.Entities.Airplanes.Contracts;

namespace Travel.Entities.Factories
{
	using Contracts;
	using Items;
	using Items.Contracts;

	public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
		    Type itemType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(c => c.Name == type);
		    return (IItem)Activator.CreateInstance(itemType);
           // switch (type)
			//{
			//	case "CellPhone":
			//		return new Colombian();
			//	case "Colombian":
			//		return new Colombian();
			//	case "Jewelery":
			//		return new Jewelery();
			//	case "Laptop":
			//		return new Laptop();
			//	case "Toothbrush":
			//		return new Toothbrush();
			//	case "TravelKit":
			//		return new TravelKit();
			//	default:
			//		throw new InvalidOperationException($"No item whit {} name!");
			//}
		}
	}
}
