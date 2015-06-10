namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public int Count { get; set; }

        [Required]
        public int BookmarkId { get; set; }

        public virtual Bookmark Bookmark { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}