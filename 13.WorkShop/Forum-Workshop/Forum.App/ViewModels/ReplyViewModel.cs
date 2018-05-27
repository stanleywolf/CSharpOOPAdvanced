using Forum.App.Contracts;

namespace Forum.App.ViewModels
{
    public class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        public string Author { get; }
        public string[] Content { get; }

        public ReplyViewModel(string author, string content)
            :base(content)
        {
            this.Author = author;
            this.Content = base.Content;
        }
    }
}
