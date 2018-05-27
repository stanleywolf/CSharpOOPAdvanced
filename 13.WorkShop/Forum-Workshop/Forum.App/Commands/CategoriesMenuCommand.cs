using System;
using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class CategoriesMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public CategoriesMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            var currentTypeName = this.GetType().Name.Replace("Command", String.Empty);

            IMenu menu = this.menuFactory.CreateMenu(currentTypeName);

            return menu;
        }
    }
}
