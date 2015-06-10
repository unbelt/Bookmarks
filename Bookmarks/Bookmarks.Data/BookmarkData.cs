namespace Bookmarks.Data
{
    using System;
    using System.Collections.Generic;

    using Bookmarks.Data.Contracts;
    using Bookmarks.Data.Repositories;
    using Bookmarks.Models;

    public class BookmarkData : IBookmarkData
    {
        private readonly IBookmarkDbContext context;
        private readonly Dictionary<Type, object> repository;

        public BookmarkData(IBookmarkDbContext context)
        {
            this.context = context;
            this.repository = new Dictionary<Type, object>();
        }

        public IBookmarkDbContext Context
        {
            get { return this.context; }
        }

        public IGenericRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IGenericRepository<Bookmark> Bookmarks
        {
            get { return this.GetRepository<Bookmark>(); }
        }

        public IGenericRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IGenericRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IGenericRepository<Vote> Votes
        {
            get { return this.GetRepository<Vote>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repository.ContainsKey(typeof(T))) { }
            {
                var type = typeof(GenericRepository<T>);
                repository.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)repository[typeof(T)];
        }
    }
}