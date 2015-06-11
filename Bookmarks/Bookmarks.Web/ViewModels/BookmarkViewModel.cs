namespace Bookmarks.Web.ViewModels
{
    using System.Collections.Generic;

    using Bookmarks.Models;
    using Bookmarks.Web.Infrastructure.Mappings;

    public class BookmarkViewModel : IMapFrom<Bookmark>
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}