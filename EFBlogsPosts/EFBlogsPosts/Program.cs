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

                //var db = new BloggingContext();
                string name;
                do
                {
                    Console.Write("Blog Manager\n1. Display all blogs\n2. Add Blog\n3. Create Post\n4. Display Posts\n5. Edit Blog\n6. Edit Post\n7. Delete Blog\n8. Delete Post\nEnter q to quit\n");

                    name = Console.ReadLine();
                    switch (name)
                    {
                        case "1":
                            // Display all Blogs from the database
                            var db = new BloggingContext();
                            Console.Clear();
                            logger.Info("Option 1 Selected");
                            int blogCount = db.Blogs.Count();
                            Console.WriteLine($"{blogCount} blogs returned:");
                            var query = db.Blogs.OrderBy(b => b.Name);
                            
                            foreach (var item in query)
                            {
                                Console.WriteLine(item.Name);
                            }
                            db.doSave();
                            Console.WriteLine();
                            break;
                        case "2":
                            using (var bb = new BloggingContext()) 
                            {
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
                                    bb.AddBlog(blog);
                                    //blog.BlogId = blogId;

                                    logger.Info("Blog added - {name}", name);
                                    bb.doSave();
                                    break;
                                }
                                
                            } 
                            
                            
                        case "3":
                            using (var cc = new BloggingContext())
                            {
                                Console.Clear();
                                logger.Info("Option 3 Selected");
                                Console.WriteLine("Please select the blog to post to:");
                                var search = cc.Blogs.OrderBy(b => b.Name);
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

                                        var post = new Post();
                                        post.Title = title;
                                        post.Content = content;
                                        post.BlogId = item.BlogId;
                                        cc.AddPost(post);

                                    }
                                    else if (select == "\n" || select == null) { Console.Clear(); Console.WriteLine("Invalid Blog Id"); }
                                    
                                }
                                cc.doSave();
                            }
                                break;
                        case "4":
                            Console.Clear();
                            logger.Info("Option 4 Selected");
                            using (var ee = new BloggingContext())
                            {
                                Console.WriteLine("Select the blog's posts to display:");

                                var blogListings = ee.Blogs.OrderBy(b => b.BlogId).ToList();
                                var blogIdListings = ee.Blogs.OrderBy(b => b.BlogId);

                                var postBlogListings = ee.Posts.OrderBy(p => p.BlogId).ToList();
                                var postBlogId = ee.Posts.OrderBy(p => p.BlogId);

                                Console.WriteLine("0. Posts from All Blogs");

                                for (int i = 0; i < blogListings.Count; i++)
                                {
                                    Console.WriteLine($"{blogListings[i].BlogId}: {blogListings[i].Name}");


                                }
                                var postSelect = Console.ReadLine();
                                if (postSelect == "0")
                                {
                                    Console.Clear();
                                    for (int i = 0; i < blogListings.Count; i++)
                                    {
                                        Console.WriteLine($"Blog: {blogListings[i].Name}\n");
                                        foreach (var postItem in postBlogId)
                                        {
                                            if (postItem.BlogId == blogListings[i].BlogId)
                                            {
                                                Console.WriteLine($"Title: {postItem.Title}");
                                                Console.WriteLine($"Content: {postItem.Content}\n");
                                            }



                                        }

                                    }


                                }
                                else if (Convert.ToInt32(postSelect) > 0)
                                {
                                    Console.Clear();
                                    foreach (var item in blogIdListings)
                                    {
                                        if (Convert.ToInt32(postSelect) == item.BlogId)
                                        {
                                            Console.WriteLine($"Blog: {item.Name}\n");

                                            for (int i = 0; i < postBlogListings.Count; i++)
                                            {
                                                if (postBlogListings[i].BlogId == Convert.ToInt32(postSelect))
                                                {
                                                    Console.WriteLine($"Title: {postBlogListings[i].Title}");
                                                    Console.WriteLine($"Content:{postBlogListings[i].Content}\n");
                                                }
                                            }
                                        }
                                    }
                                }
                                else { Console.WriteLine("Invalid Blog Id"); logger.Info("Invalid BlogId Entered"); break; }
                                ee.Dispose();   
                            }
                                break;
                        case "5":
                            Console.Clear();
                            logger.Info("Option 5 Selected");
                            using (var ff = new BloggingContext())
                            {
                                var blogList = ff.Blogs.OrderBy(b => b.BlogId);
                                Console.WriteLine("Select the Blog to Edit:");
                                foreach (var item in blogList)
                                {
                                    Console.WriteLine($"{item.BlogId}: {item.Name}");
                                }
                                string select = Console.ReadLine();
                                foreach (var item in blogList)
                                {
                                    if (select == Convert.ToString(item.BlogId))
                                    {
                                        Console.WriteLine($"Enter the new Blog Name. Previous Blog Name was: {item.Name}");
                                        string newName = Console.ReadLine();
                                        item.Name = newName;

                                        Console.WriteLine($"Blog Edited Successfully.\n\nNew Name: {item.Name}");
                                    }
                                    
                                }

                                ff.doSave();
                                ff.Dispose();
                            }
                            
                            break;
                        case "6":
                            using (var gg = new BloggingContext())
                            {
                                Console.Clear();
                                logger.Info("Option 6 Selected");
                                Console.WriteLine("Please select the blog to edit posts:");
                                var search = gg.Blogs.OrderBy(b => b.Name);
                                var postEditSearch = gg.Posts.OrderBy(p => p.PostId);
                                foreach (var item in search)
                                {
                                    Console.WriteLine($"{item.BlogId}. {item.Name}");
                                }

                                var select = Console.ReadLine();
                                Console.WriteLine("Please select the post to edit:");
                                foreach (var item in postEditSearch)
                                {
                                    if (Convert.ToString(item.BlogId) == select)
                                    {
                                        
                                        Console.WriteLine($"{item.PostId}. {item.Title}");
                                    }
                                }
                                        string postSearchSelect = Console.ReadLine();
                                foreach (var item in postEditSearch)
                                    {
                                        if(postSearchSelect == Convert.ToString(item.PostId))
                                            {
                                                Console.WriteLine($"Enter the new post title. Previous was: {item.Title}");
                                                item.Title = Console.ReadLine();
                                                Console.Write($"Enter the new post body. Previous was:\n\n{item.Content}\n\n");
                                                item.Content = Console.ReadLine();

                                                Console.WriteLine($"Post Edited Successfully.\n\nNew Title: {item.Title}\n\nNew Content: {item.Content}");
                                            }
                                            
                                    }





                                gg.doSave();
                                gg.Dispose();

                            }
                                
                            break;
                        case "7":
                            Console.Clear();
                            logger.Info("Option 7 Selected");
                            Console.WriteLine("Select the Blog to Delete:");
                            using (var hh = new BloggingContext()) 
                            {
                                var deleteBlog = hh.Blogs.OrderBy(b => b.BlogId);
                                foreach (var item in deleteBlog)
                                {
                                    Console.WriteLine($"{item.BlogId}: {item.Name}");
                                }
                                string deleteBlogSelector = Console.ReadLine();
                                var cleanPostsDelete = hh.Posts.OrderBy(p => p.BlogId);
                                foreach(var item in deleteBlog)
                                {
                                    if(deleteBlogSelector == Convert.ToString(item.BlogId))
                                    {
                                        Console.WriteLine("Are you sure you want to delete this blog and all blog posts? (Y/N)");
                                        string confirmBlogDelete = Console.ReadLine();
                                        if (confirmBlogDelete == "Y" || confirmBlogDelete == "y")
                                        {
                                            hh.Blogs.Remove(item);
                                            Console.WriteLine("\nBlog Deleted Successfully.");
                                        }
                                        else break;
                                        
                                    }
                                }
                                foreach (var postItem in cleanPostsDelete)
                                {
                                    if (Convert.ToString(postItem.BlogId) == deleteBlogSelector)
                                    {
                                        hh.Posts.Remove(postItem);
                                        Console.WriteLine("Removing Posts.");
                                    }
                                }
                                hh.doSave();
                                hh.Dispose();

                            }
                                
                            break;
                        case "8":
                            Console.Clear();
                            logger.Info("Option 8 Selected");
                            Console.WriteLine("Select the blog from which to delete posts.");
                            using(var ii = new BloggingContext())
                            {
                                var deletePostsBlog = ii.Blogs.OrderBy(b => b.BlogId);
                                var deletePostsList = ii.Posts.OrderBy(p => p.PostId);
                                foreach(var item in deletePostsBlog)
                                {
                                    Console.WriteLine($"{item.BlogId}. {item.Name}");
                                }
                                string deletePostsBlogSelect = Console.ReadLine();
                                foreach(var item in deletePostsList)
                                {
                                    if(Convert.ToString(item.BlogId) == deletePostsBlogSelect)
                                    {
                                        Console.WriteLine($"{item.PostId}. {item.Title}");
                                    }
                                }
                                string deletePostsSelect = Console.ReadLine();
                                
                                foreach(var item in deletePostsList)
                                {
                                    if(deletePostsSelect == Convert.ToString(item.PostId))
                                    {
                                        Console.WriteLine($"Are you sure you want to delete the post titled \"{item.Title}\"? (Y/N)");
                                        string confirmDeletePost = Console.ReadLine();
                                        if(confirmDeletePost == "y" || confirmDeletePost == "Y")
                                        {
                                            ii.Posts.Remove(item);
                                            Console.WriteLine("Post deleted Successfully.");
                                        }
                                    }
                                }
                                ii.doSave();
                                ii.Dispose();
                            }
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