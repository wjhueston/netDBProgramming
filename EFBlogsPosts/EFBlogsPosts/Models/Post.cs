
namespace BlogsConsole.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }


        /*public Post() { }
        public Post(string title, string content, int blogId)
        {

            this.Title = title;
            this.Content = content;
            this.BlogId = blogId;
        }
        */
    }
}
