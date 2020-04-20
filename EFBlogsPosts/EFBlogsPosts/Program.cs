using NLog;
using BlogsConsole.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BlogsConsole
{
    class MainClass
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static void Main(string[] args)
        {
            logger.Info("Program started");
            try
            {

                // Create and save a new Blog

                var db = new BloggingContext();
                string name;
                do
                {
                    Console.Write("Blog Manager\n1. Display all blogs\n2. Add Blog\n3. Create Post\n4. Display Posts\nEnter q to quit\n");

                    name = Console.ReadLine();
                    switch (name)
                    {
                        case "1":
                            // Display all Blogs from the database
                            Console.Clear();
                            logger.Info("Option 1 Selected");
                            int blogCount = db.Blogs.Count();
                            Console.WriteLine($"{blogCount} blogs returned:");
                            var query = db.Blogs.OrderBy(b => b.Name);
                            
                            foreach (var item in query)
                            {
                                Console.WriteLine(item.Name);
                            }
                            Console.WriteLine();
                            break;
                        case "2":
                            Console.Clear();
                            logger.Info("Option 2 Selected");
                            Console.WriteLine("Enter a name for your blog.");
                            string blogName = Console.ReadLine();
                            if (blogName == null) { Console.WriteLine("Blog Name cannot be null"); break; }
                            else
                            {
                                //int blogId = db.Blogs.Max(b => b.BlogId) + 1;
                                var blog = new Blog();
                                blog.Name = blogName;
                                db.AddBlog(blog);
                                //blog.BlogId = blogId;

                                logger.Info("Blog added - {name}", name);
                                db.doSave();
                                break;
                            }
                            
                        case "3":
                            Console.Clear();
                            logger.Info("Option 3 Selected");
                            Console.WriteLine("Please select the blog to post to:");
                            var search = db.Blogs.OrderBy(b => b.Name);
                            //var idSearch = db.Blogs.OrderBy(b => b.BlogId);
                            foreach (var item in search)
                            {
                                Console.WriteLine($"{item.BlogId}. {item.Name}");
                            }
                            
                            var select = Console.ReadLine();
                            foreach (var item in search)
                            {
                                if (select == Convert.ToString(item.BlogId))
                                {


                                    Console.WriteLine("Enter the Title of the Post");
                                    var title = Console.ReadLine();

                                    Console.WriteLine("Enter the content of the Post");
                                    var content = Console.ReadLine();

                                    var post = new Post(title, content, item.BlogId);

                                    db.AddPost(post);

                                }
                                else if (select == "\n" || select == null) { Console.Clear(); Console.WriteLine("Invalid Blog Id");  }
                                else { Console.Clear(); Console.WriteLine("There are no blogs saved with that Id");  }
                            }
                            db.doSave();
                            break;
                        case "4":
                            Console.WriteLine("Select the blog's posts to display:");
                            var postCheck = db.Blogs.OrderBy(b => b.Name);
                            List<int> postBlogArray = new List<int>();
                            foreach (var item in db.Blogs.OrderBy(b => b.BlogId))
                            {
                                postBlogArray.Add(item.BlogId);
                            }
                            Console.WriteLine("0. Posts from All Blogs");
                            foreach (var item in postCheck)
                            {
                                Console.WriteLine($"{item.BlogId}. Posts from {item.Name}");
                                
                            }
                            
                            var postSelect = Console.ReadLine();
                            if(postSelect == "0") 
                            {
                                
                                foreach(var item in postCheck)
                                {
                                    Console.WriteLine($"Blog: {item.Name}");
                                    var postSearch = db.Posts.OrderBy(p => p.Title);
                                    
                                    foreach (var postItem in postSearch)
                                    {
                                        if(postItem.BlogId == item.BlogId)
                                        {
                                            Console.WriteLine($"Title: {postItem.Title}");
                                            Console.WriteLine($"Content: {postItem.Content}");
                                            Console.WriteLine();
                                        }
                                        
                                    }
                                    Console.WriteLine();
                                }
                            }
                            else if (postBlogArray.Contains(Convert.ToInt32(postSelect))) 
                            {
                                foreach(var item in postCheck)
                                {
                                    if(item.BlogId == Convert.ToInt32(postSelect))
                                    {
                                        var postSearch = db.Posts.OrderBy(p => p.Title);
                                        foreach (var postItem in postSearch)
                                        {
                                            if (postItem.BlogId == item.BlogId)
                                            {
                                                Console.WriteLine($"Title: {postItem.Title}");
                                                Console.WriteLine($"Content: {postItem.Content}");
                                                Console.WriteLine();
                                            }

                                        }
                                        Console.WriteLine();
                                    }
                                }
                            }
                            else { Console.WriteLine("Invalid Blog Selection."); }
                            break;
                        default: break;
                    }
                }
                while (name != "q");





            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            logger.Info("Program ended");
        }
    }
}