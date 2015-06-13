namespace Bookmarks.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Bookmarks.Models;
    using Bookmarks.Web.Infrastructure.Mappings;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public CommentViewModel()
        {
            this.Date = DateTime.Now;
        }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
    }
}