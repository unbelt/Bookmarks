namespace Bookmarks.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNet.Identity;

    using Bookmarks.Data.Contracts;
    using Bookmarks.Models;
    using Bookmarks.Web.ViewModels;

    public class BaseController : Controller
    {
        private const string ControllerString = "Controller";

        public BaseController()
        {
        }

        public BaseController(IBookmarkData data)
        {
            this.Data = data;

            this.BookmarksSummary = this.Data.Bookmarks.All()
                .OrderBy(b => b.Votes.Count)
                .Project().To<BookmarkSummaryViewModel>()
                .ToList();

            this.Bookmarks = this.Data.Bookmarks.All()
                .OrderBy(b => b.Votes.Count)
                .Project().To<BookmarkViewModel>()
                .ToList();
        }

        public IBookmarkData Data { get; set; }

        public ICollection<BookmarkViewModel> Bookmarks { get; set; }

        public ICollection<BookmarkSummaryViewModel> BookmarksSummary { get; set; }

        [ChildActionOnly]
        public IQueryable<User> GetUsersInRole(string roleName)
        {
            var userRolesId = this.Data.Context.RoleManager
                .FindByName(roleName).Users.Select(r => r.UserId);

            var users = this.Data.Users.All()
                .Where(u => userRolesId.Contains(u.Id));

            return users;
        }

        [ChildActionOnly]
        public bool IsAdmin()
        {
            var userId = this.User.Identity.GetUserId();
            var isAdmin = (userId != null && this.User.IsInRole("Admin"));

            return isAdmin;
        }

        [ChildActionOnly]
        protected ActionResult RedirectToAction<T>(Expression<Action<T>> action) where T : Controller
        {
            var methodName = ((MethodCallExpression)action.Body).Method.Name;
            var controllerName = typeof(T).Name.Replace(ControllerString, string.Empty);

            return RedirectToAction(methodName, controllerName);
        }
    }
}