using System.Collections.Generic;
using System.Linq;
using Forum.App.Contracts;

namespace Forum.App.ViewModels
{
    public class PostViewModel : ContentViewModel, IPostViewModel
    {
        public string Title { get; }
        public string Author { get; }
        public IReplyViewModel[] Replies { get; }

        public PostViewModel(string title, string author, string content, IEnumerable<IReplyViewModel> replies)
            :base(content)
        {
            this.Title = title;
            this.Author = author;
            this.Replies = replies.ToArray();
        }
    }
}
