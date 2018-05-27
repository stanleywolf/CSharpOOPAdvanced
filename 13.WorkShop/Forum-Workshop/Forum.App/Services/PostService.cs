 using System;
using System.Collections.Generic;
using System.Linq;
using Forum.App.Contracts;
using Forum.App.ViewModels;
using Forum.Data;
using Forum.DataModels;

namespace Forum.App.Services
{
    public class PostService : IPostService
    {
        private ForumData forumData;
        private IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            return this.forumData
                .Categories
                .Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            return this.forumData.Posts
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new PostInfoViewModel(p.Id, p.Title, p.Replies.Count));
        }

        public string GetCategoryName(int categoryId)
        {
            var categoryName = this.forumData.Categories.FirstOrDefault(c => c.Id == categoryId)?.Name;

            if (categoryName == null)
            {
                throw new ArgumentException($"Category with id {categoryId} not found!");
            }

            return categoryName;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            var post = this.forumData.Posts.FirstOrDefault(p => p.Id == postId);

            string author = this.userService.GetUserName(post.AuthorId);

            IPostViewModel postViewModel = new PostViewModel(post.Title, author, post.Content, this.GetPostReplies(postId));

            return postViewModel;
        }

        private IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            return this.forumData.Replies
                .Where(r => r.Id == postId)
                .Select(r => new ReplyViewModel(this.userService.GetUserName(r.AuthorId), r.Content));
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postCategory);
            bool emptyTitle = string.IsNullOrWhiteSpace(postTitle);
            bool emptyContent = string.IsNullOrWhiteSpace(postContent);

            if (emptyCategory || emptyTitle || emptyContent)
            {
                throw new ArgumentException("All fields must be filled!");
            }

            Category category = this.EnsureCategory(postCategory);

            int postId = this.forumData.Posts.Any() ? this.forumData.Posts.Last().Id + 1 : 1;

            User author = this.userService.GetUserById(userId);

            Post post = new Post(postId, postTitle, postContent, category.Id, author.Id, new List<int>());

            this.forumData.Posts.Add(post);
            author.Posts.Add(postId);
            category.Posts.Add(postId);
            this.forumData.SaveChanges();

            return postId;
        }

        private Category EnsureCategory(string postCategory)
        {
            var category = this.forumData.Categories.FirstOrDefault(c => c.Name == postCategory);

            if (category == null)
            {
                int categoryId = this.forumData.Categories.Any() ? this.forumData.Categories.Last().Id + 1 : 1;

                category = new Category(categoryId, postCategory, new List<int>());

                this.forumData.Categories.Add(category);
                this.forumData.SaveChanges();
            }

            return category;
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            if (string.IsNullOrWhiteSpace(replyContents))
            {
                throw new ArgumentException("All fields must be filled!");
            }

            int replyId = this.forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;

            Reply reply = new Reply(replyId, replyContents, userId, postId);
            Post post = this.forumData.Posts.SingleOrDefault(p => p.Id == postId);

            this.forumData.Replies.Add(reply);
            post.Replies.Add(replyId);
            this.forumData.SaveChanges();
        }
    }
}
