using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UseXPagedListMVC.Models;
using UseXPagedListMVC.Utils;
using X.PagedList;

namespace UseXPagedListMVC.Controllers
{
    public class UsersController : Controller
    {
        private UsersContext db = new UsersContext();

        private readonly int defaultPageSize
            = Convert.ToInt32(DefaultValuesForPaging.ItemsPerPageList.SelectedValue);

        //private static readonly IEnumerable<User> usersInitializationList
        //    = UserPersonalDataGenerator.GenerateDataSet(313);

        // GET: Users
        public ActionResult List(string searchString, string sortOrder, int? page, int? pageSize)
        {
            ViewBag.IDSortParm = sortOrder == "ID" ? "ID_desc" : "ID";
            ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.SNameSortParm = sortOrder == "sname" ? "sname_desc" : "sname";
            ViewBag.AgeSortParm = sortOrder == "age" ? "age_desc" : "age";
            ViewBag.IsStudentSortParm = sortOrder == "student" ? "student_desc" : "student";

            /*
             *  Для PagedListPager во View-шке
             */
            ViewBag.SortOrder = sortOrder;
            /*
            *  Для ссылок во View-шке
            */
            ViewBag.SearchString = searchString;

            /*
             *  Выборка из БД
             */
            var dbSet = db.Users
                .Select(u => u);

            /*
             *  Поиск
             */
            if (!String.IsNullOrEmpty(searchString))
            {
                dbSet = dbSet.Where(us => us.Name.Contains(searchString)
                                       || us.SName.Contains(searchString));
            }

            /*
             *  Сортировка
             *  
             *  Можно вынести в отдельный метод
             */
            switch (sortOrder)
            {
                case "ID_desc":
                    dbSet = dbSet.OrderByDescending(s => s.ID);
                    break;
                case "name":
                    dbSet = dbSet.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    dbSet = dbSet.OrderByDescending(s => s.Name);
                    break;
                case "sname":
                    dbSet = dbSet.OrderBy(s => s.SName);
                    break;
                case "sname_desc":
                    dbSet = dbSet.OrderByDescending(s => s.SName);
                    break;
                case "age":
                    dbSet = dbSet.OrderBy(s => s.Age);
                    break;
                case "age_desc":
                    dbSet = dbSet.OrderByDescending(s => s.Age);
                    break;
                case "student":
                    dbSet = dbSet.OrderBy(s => s.IsStudent);
                    break;
                case "student_desc":
                    dbSet = dbSet.OrderByDescending(s => s.IsStudent);
                    break;
                default:
                    dbSet = dbSet.OrderBy(s => s.ID);
                    break;
            }

            var users = dbSet
                .Select(us => us);

            int pageNumber = page ?? 1;

            var itemsPerPageList = DefaultValuesForPaging.ItemsPerPageList.Select(v => Convert.ToInt32(v.Text));

            pageSize = pageSize ?? defaultPageSize;

            int pgSz = (int)pageSize;

            /*
             *  SelectItems
             */
            pgSz = itemsPerPageList.Contains(pgSz) ? pgSz : defaultPageSize;

            var pagedUsers = users.ToList().ToPagedList(pageNumber, pgSz);

            ViewBag.PageSize = pagedUsers.PageSize;
            ViewBag.PageNumber = pagedUsers.PageNumber;
            ViewBag.PagesCount = pagedUsers.PageCount;
            ViewBag.TotalCount = pagedUsers.TotalItemCount;


            return View(pagedUsers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
