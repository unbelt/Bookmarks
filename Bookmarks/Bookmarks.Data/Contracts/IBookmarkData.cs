namespace Bookmarks.Data.Contracts
{
    using Bookmarks.Models;

    public interface IBookmarkData
    {
        IBookmarkDbContext Context { get; }

        IGenericRepository<User> Users { get; }

        IGenericRepository<Bookmark> Bookmarks { get; }

        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Vote> Votes { get; }

        int SaveChanges();

        void Dispose();
    }
}