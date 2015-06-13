namespace Bookmarks.Web.ViewModels
{
    using Bookmarks.Models;
    using Bookmarks.Web.Infrastructure.Mappings;

    public class BookmarkSummaryViewModel : IMapFrom<Bookmark>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}