using System;
using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class ViewPostMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public ViewPostMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int postId = int.Parse(args[0]);

            var currentTypeName = this.GetType().Name.Replace("Command", String.Empty);

            var menu = (IIdHoldingMenu)this.menuFactory.CreateMenu(currentTypeName);
            menu.SetId(postId);

            return menu;
        }
    }
}
