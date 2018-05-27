using System;
using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class AddPostMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public AddPostMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string menuName = this.GetType().Name.Replace("Command", String.Empty);

            return this.menuFactory.CreateMenu(menuName);
        }
    }
}
