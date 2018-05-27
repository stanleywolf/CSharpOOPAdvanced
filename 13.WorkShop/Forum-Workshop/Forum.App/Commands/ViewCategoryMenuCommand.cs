using System;
using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class ViewCategoryMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public ViewCategoryMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int categoryId = int.Parse(args[0]);

            var currentTypeName = this.GetType().Name.Replace("Command", String.Empty);

            var menu = (IIdHoldingMenu) this.menuFactory.CreateMenu(currentTypeName);
            menu.SetId(categoryId);

            return menu;
        }
    }
}
