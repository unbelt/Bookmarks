namespace Bookmarks.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Bookmarks.Data.Contracts;
    using Bookmarks.Models;
    using Bookmarks.Web.Extensions;
    using Bookmarks.Web.ViewModels;

    [Authorize]
    public class BookmarkController : BaseController
    {
        public BookmarkController(IBookmarkData data)
            : base(data)
        {
            ViewData["Categories"] = this.Data.Categories.All()
                .Project().To<CategoryViewModel>();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var bookmark = this.Bookmarks.FirstOrDefault(b => b.Id == id);

            if (bookmark == null)
            {
                return HttpNotFound();
            }

            return View(bookmark);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookmarkViewModel entry)
        {
            if (!this.ModelState.IsValid)
            {
                return View(entry);
            }

            Mapper.CreateMap<BookmarkViewModel, Bookmark>();
            var bookmark = Mapper.Map<Bookmark>(entry);

            this.Data.Bookmarks.Add(bookmark);
            this.Data.SaveChanges();

            this.AddNotification("Bookmark created!", NotificationType.SUCCESS);

            return this.RedirectToAction<HomeController>(c => c.Index());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bookmark = this.Bookmarks.FirstOrDefault(b => b.Id == id);

            if (bookmark == null)
            {
                return HttpNotFound();
            }

            return View(bookmark);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookmarkViewModel entry)
        {
            if (!this.ModelState.IsValid)
            {
                return View(entry);
            }

            Mapper.CreateMap<BookmarkViewModel, Bookmark>();
            var bookmark = Mapper.Map<Bookmark>(entry);

            this.Data.Bookmarks.Update(bookmark);
            this.Data.SaveChanges();

            this.AddNotification("Bookmark edited!", NotificationType.INFO);

            return this.RedirectToAction<HomeController>(c => c.Index());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (this.IsAdmin())
            {
                this.Data.Bookmarks.Delete(id);
                this.Data.SaveChanges();
            }

            this.AddNotification("Bookmark deleted!", NotificationType.INFO);

            return this.RedirectToAction<HomeController>(c => c.Index());
        }
    }
}