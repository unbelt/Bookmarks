namespace Bookmarks.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using Bookmarks.Models;
    using Bookmarks.Web.Infrastructure.Mappings;

    public class BookmarkSummaryViewModel : IMapFrom<Bookmark>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 2)]
        public string Description { get; set; }
    }
}