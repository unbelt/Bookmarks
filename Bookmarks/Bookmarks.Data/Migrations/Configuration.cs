namespace Bookmarks.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    using Bookmarks.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<BookmarkDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // TODO: Remove in production
        }

        protected override void Seed(BookmarkDbContext context)
        {
            try
            {
                SeedRoles(context);
                SeedUsers(context);
                SeedCategories(context);
                context.SaveChanges();

                SeedBookmarks(context);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }

                throw;
            }
        }

        private static void SeedRoles(BookmarkDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(context.RoleStore);

            var roles = new List<string>
            {
                "Admin",
                "User",
                "Guest"
            };

            foreach (var role in roles)
            {
                if (roleManager.FindByName(role) == null)
                {
                    roleManager.Create(new IdentityRole(role));
                }
            }
        }

        private static void SeedUsers(BookmarkDbContext context)
        {
            var userStore = context.UserStore;
            var userManager = new UserManager<User>(userStore);

            var users = new List<User>
            {
                new User
                {
                    UserName = "admin",
                    Email = "admin@admin.com"
                },
                new User
                {
                    UserName = "user",
                    Email = "user@user.com"
                }
            };

            foreach (var user in users)
            {
                if (userManager.FindByName(user.UserName) == null)
                {
                    userManager.Create(user, "pass123");
                    userManager.SetLockoutEnabled(user.Id, false);
                    userManager.AddToRole(user.Id, "User");

                    if (user.UserName == "admin")
                    {
                        userManager.AddToRole(user.Id, "Admin");
                    }
                }
            }
        }

        private static void SeedCategories(BookmarkDbContext context)
        {
            var categories = new List<string>
            {
                "Books",
                "Movies",
                "Articles"
            };

            foreach (var category in categories)
            {
                context.Categories.AddOrUpdate(c => c.Name, new Category()
                {
                    Name = category
                });
            }
        }

        private static void SeedBookmarks(BookmarkDbContext context)
        {
            var bookmarks = new List<Bookmark>
            {
                new Bookmark()
                {
                    Category = context.Categories.FirstOrDefault(c => c.Name == "Books"),
                    Title = "Computer Programming with C#",
                    Url = "http://www.introprogramming.info/",
                    Description = "The book 'Fundamentals of Computer Programming with C#' is an excellent manual to guide you through your journey of programming as beginner.",
                    Comments = new List<Comment>()
                    {
                        new Comment()
                        {
                            User = context.Users.FirstOrDefault(u => u.UserName == "user"),
                            Text = "Great book!"
                        }
                    }
                }
            };

            foreach (var bookmark in bookmarks)
            {
                context.Bookmarks.AddOrUpdate(b => b.Url, bookmark);
            }
        }
    }
}