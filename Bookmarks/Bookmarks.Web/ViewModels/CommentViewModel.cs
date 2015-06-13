namespace Bookmarks.Web.ViewModels
{
    using System;

    using Bookmarks.Models;
    using Bookmarks.Web.Infrastructure.Mappings;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Text { get; set; }

        public DateTime Date { get; set; }

        public virtual User User { get; set; }
    }
}