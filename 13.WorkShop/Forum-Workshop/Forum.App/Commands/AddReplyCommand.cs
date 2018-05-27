using System;
using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class AddReplyCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public AddReplyCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int posyId = int.Parse(args[0]);

            string menuName = this.GetType().Name.Replace("Command", String.Empty) + "Menu";
            var menu = (IIdHoldingMenu)this.menuFactory.CreateMenu(menuName);
            menu.SetId(posyId);

            return menu;
        }
    }
}
