using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class SubmitCommand : ICommand
    {
        private ISession session;
        private IPostService postService;

        public SubmitCommand(ISession session, IPostService postService)
        {
            this.session = session;
            this.postService = postService;
        }

        public IMenu Execute(params string[] args)
        {
            string content = args[0];
            int postId = int.Parse(args[1]);
            int userId = this.session.UserId;

            this.postService.AddReplyToPost(postId, content, userId);

            return this.session.Back();
        }
    }
}
