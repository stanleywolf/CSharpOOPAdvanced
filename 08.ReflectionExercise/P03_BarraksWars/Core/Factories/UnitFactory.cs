using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);

            if (model == null)
            {
                throw new ArgumentException("Invali Unit Type!");
            }
            if (!typeof(IUnit).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{unitType} is Not a Unit type!");
            }

            IUnit unit = (IUnit) Activator.CreateInstance(model);
            return unit;
        }
    }
}
