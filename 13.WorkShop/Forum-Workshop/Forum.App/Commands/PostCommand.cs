using Forum.App.Contracts;
using Forum.DataModels;

namespace Forum.App.Commands
{
    public class PostCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        private ICommandFactory commandFactory;

        public PostCommand(ISession session, IPostService postService, ICommandFactory commandFactory)
        {
            this.session = session;
            this.postService = postService;
            this.commandFactory = commandFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int userId = this.session.UserId;

            string postTitle = args[0];
            string postCategory = args[1];
            string postContents = args[2];

            int postId = this.postService.AddPost(userId, postTitle, postCategory, postContents);

            this.session.Back();

            ICommand viewPostCommand = this.commandFactory.CreateCommand("ViewPostMenu");

            return viewPostCommand.Execute(postId.ToString());
        }
    }
}
