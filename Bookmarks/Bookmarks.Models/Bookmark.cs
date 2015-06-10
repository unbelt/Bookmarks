namespace Bookmarks.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Bookmark
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Url { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [StringLength(500, MinimumLength = 2)]
        public string Description { get; set; }
    }
}