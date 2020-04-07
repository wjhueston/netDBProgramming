using System;
using System.Data.Entity;

namespace BlogsConsole.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext() : base("name=BlogContext") { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public void AddBlog(Blog blog)
        {
            this.Blogs.Add(blog);


        }
        public void AddPost(Post p)
        {

            this.Posts.Add(p);

        }
        public void doSave()
        {
            this.SaveChanges();
        }

    }
}
