using System;
using System.Linq;
using System.Reflection;
using P03_BarraksWars.Core.Commands;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName + "command");
            if (commandType == null)
            {
                throw new ArgumentException("Invalid command!");
            }
            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandName} is not a Command!");
            }

            FieldInfo[] fieldsToInj = commandType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

            object[] injectArgs = fieldsToInj.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

            object[] constrArgs = new object[] {data}.Concat(injectArgs).ToArray();


            IExecutable instance = (IExecutable) Activator.CreateInstance(commandType, constrArgs);

            return instance;

        }
    }
}

    
