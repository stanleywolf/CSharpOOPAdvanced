using System.Collections.Generic;
using System.Linq;

namespace Forum.App.ViewModels
{
    public class ContentViewModel
    {
        private const int LineLength = 37;

        public string[] Content { get; }

        public ContentViewModel(string content)
        {
            this.Content = this.GetLines(content);
        }

        private string[] GetLines(string content)
        {
            var contentChars = content.ToCharArray();
            ICollection<string> lines = new List<string>();
            
            for (int i = 0; i < contentChars.Length; i += LineLength)
            {
                var row = contentChars.Skip(i).Take(LineLength).ToArray();
                var rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines.ToArray();
        }
    }
}
