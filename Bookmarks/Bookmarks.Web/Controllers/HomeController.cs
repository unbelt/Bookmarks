namespace Bookmarks.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Bookmarks.Data.Contracts;

    public class HomeController : BaseController
    {
        public HomeController(IBookmarkData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var bookmarks = this.Data.Bookmarks.All();

            return View(bookmarks);
        }
    }
}