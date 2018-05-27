using System;
using System.Linq;
using System.Reflection;
using Forum.App.Contracts;

namespace Forum.App.Factories
{
    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var typeOfMenu = assembly
                .GetTypes()
                .SingleOrDefault(c => c.Name == $"{menuName}");

            if (typeOfMenu == null)
            {
                throw new InvalidOperationException($"{menuName} not found!");
            }

            if (!typeof(IMenu).IsAssignableFrom(typeOfMenu))
            {
                throw new InvalidOperationException($"“{typeOfMenu} is not a menu!");
            }

            var constructorParams = typeOfMenu
                .GetConstructors()
                .First()
                .GetParameters();

            var args = new object[constructorParams.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(constructorParams[i].ParameterType);
            }

            IMenu command = (IMenu)Activator.CreateInstance(typeOfMenu, args);

            return command;
        }
    }
}
