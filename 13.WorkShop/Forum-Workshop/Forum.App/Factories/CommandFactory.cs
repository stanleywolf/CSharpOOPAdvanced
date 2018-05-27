using System;
using System.Linq;
using System.Reflection;

namespace Forum.App.Factories
{
    using Contracts;

    public class CommandFactory : ICommandFactory
    {
        private const string Suffix = "Command";
        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var typeOfCommand = assembly
                .GetTypes()
                .SingleOrDefault(c => c.Name == $"{commandName}{Suffix}");

            if (typeOfCommand == null)
            {
                throw new InvalidOperationException("Command not found!");
            }

            if (!typeof(ICommand).IsAssignableFrom(typeOfCommand))
            {
                throw new InvalidOperationException($"“{typeOfCommand} is not a command!");
            }

            var constructorParams = typeOfCommand
                .GetConstructors()
                .First()
                .GetParameters();

            var args = new object[constructorParams.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(constructorParams[i].ParameterType);
            }

            ICommand command = (ICommand)Activator.CreateInstance(typeOfCommand, args);

            return command;
        }
    }
}
