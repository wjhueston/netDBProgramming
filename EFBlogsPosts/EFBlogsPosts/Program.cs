using NLog;
using BlogsConsole.Models;
using System;
using System.Linq;


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
                    Console.Write("Blog Manager\n1. Display all blogs\n2. Add Blog\n3. Create Post\nPress any other key to exit\n");

                    name = Console.ReadLine();
                    switch (name)
                    {
                        case "1":
                            // Display all Blogs from the database
                            var query = db.Blogs.OrderBy(b => b.Name);

                            Console.WriteLine("All blogs in the database:");
                            foreach (var item in query)
                            {
                                Console.WriteLine(item.Name);
                            }

                            break;
                        case "2":
                            Console.WriteLine("Enter a name for your blog.");
                            string blogName = Console.ReadLine();
                            var blog = new Blog();


                            db.AddBlog(blog);
                            logger.Info("Blog added - {name}", name);
                            db.doSave();
                            break;
                        case "3":
                            Console.WriteLine("Please select the blog to post to:");
                            var search = db.Blogs.OrderBy(b => b.Name);
                            var idSearch = db.Blogs.OrderBy(b => b.BlogId);
                            foreach (var item in search)
                            {
                                Console.WriteLine(item.Name);
                            }
                            var select = Console.ReadLine();
                            foreach (var item in search)
                            {
                                if (select == item.Name)
                                {


                                    Console.WriteLine("Enter the Title of the Post");
                                    var title = Console.ReadLine();

                                    Console.WriteLine("Enter the content of the Post");
                                    var content = Console.ReadLine();

                                    var post = new Post(title, content, item.BlogId);

                                    db.AddPost(post);

                                }
                            }
                            db.doSave();
                            break;
                        default: break;
                    }
                }
                while (name == "1" || name == "2" || name == "3");





            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            logger.Info("Program ended");
        }
    }
}