using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class PreviousPageCommand : ICommand
    {
        private ISession session;

        public PreviousPageCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            var menu = this.session.CurrentMenu;

            if (menu is IPaginatedMenu paginatedMenu)
            {
                paginatedMenu.ChangePage(false);
            }

            return menu;
        }
    }
}
