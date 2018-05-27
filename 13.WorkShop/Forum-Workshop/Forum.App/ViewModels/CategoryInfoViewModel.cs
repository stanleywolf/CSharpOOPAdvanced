using Forum.App.Contracts;

namespace Forum.App.ViewModels
{
    public class CategoryInfoViewModel : ICategoryInfoViewModel
    {
        public int Id { get; }
        public string Name { get; }
        public int PostCount { get; }

        public CategoryInfoViewModel(int id, string name, int postCount)
        {
            this.Id = id;
            this.Name = name;
            this.PostCount = postCount;
        }
    }
}
