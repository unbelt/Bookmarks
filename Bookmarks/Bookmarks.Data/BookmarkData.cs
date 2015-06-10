namespace Bookmarks.Data
{
    using Bookmarks.Data.Contracts;
    using Bookmarks.Models;

    public class BookmarkData : IBookmarkData
    {
        public IBookmarkDbContext Context
        {
            get { throw new System.NotImplementedException(); }
        }

        public IGenericRepository<User> Users
        {
            get { throw new System.NotImplementedException(); }
        }

        public IGenericRepository<Bookmark> Bookmarks
        {
            get { throw new System.NotImplementedException(); }
        }

        public IGenericRepository<Category> Categories
        {
            get { throw new System.NotImplementedException(); }
        }

        public IGenericRepository<Vote> Votes
        {
            get { throw new System.NotImplementedException(); }
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