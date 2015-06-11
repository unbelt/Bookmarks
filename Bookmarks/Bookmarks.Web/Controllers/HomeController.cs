namespace Bookmarks.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Bookmarks.Data.Contracts;
    using Bookmarks.Web.ViewModels;

    using AutoMapper.QueryableExtensions;

    public class HomeController : BaseController
    {
        public HomeController(IBookmarkData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var bookmarks = this.Data.Bookmarks.All()
                .OrderBy(b => b.Votes.Count)
                .Project().To<BookmarkViewModel>()
                .ToList();

            return View(bookmarks);
        }
    }
}