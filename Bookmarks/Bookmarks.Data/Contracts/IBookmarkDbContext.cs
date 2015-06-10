namespace Bookmarks.Data.Contracts
{
    using System.Data.Entity;

    using Bookmarks.Models;

    public interface IBookmarkDbContext
    {
        IDbSet<User> Users { get; }

        IDbSet<Bookmark> Bookmarks { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<Vote> Votes { get; }

        DbSet<TEntity> Set<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}