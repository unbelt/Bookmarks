namespace Bookmarks.Models
{
    using System.Collections.Generic;

    public class User
    {
        private ICollection<Bookmark> bookmarks;

        public User()
        {
            this.bookmarks = new HashSet<Bookmark>();
        }

        public virtual ICollection<Bookmark> Bookmarks
        {
            get
            {
                return this.bookmarks;
            }

            set
            {
                this.bookmarks = value;
            }
        }
    }
}