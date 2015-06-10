namespace Bookmarks.Data
{
    using System.Data.Entity;

    using Bookmarks.Data.Contracts;
    using Bookmarks.Models;

    public class BookmarkDbContext : IBookmarkDbContext
    {
        public IDbSet<User> Users
        {
            get { throw new System.NotImplementedException(); }
        }

        public IDbSet<Bookmark> Bookmarks
        {
            get { throw new System.NotImplementedException(); }
        }

        public IDbSet<Category> Categories
        {
            get { throw new System.NotImplementedException(); }
        }

        public IDbSet<Vote> Votes
        {
            get { throw new System.NotImplementedException(); }
        }

        public DbSet<TEntity> Set<TEntity>(TEntity entity) where TEntity : class
        {
            throw new System.NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}