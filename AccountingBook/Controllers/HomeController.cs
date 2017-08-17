using AccountingBook.Models;
using AccountingBook.Repositories;
using AccountingBook.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountingBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountService _accountSvc;

        private int pageSize = 10;

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountSvc = new AccountService(unitOfWork);
        }

        public ActionResult Index(int page = 1)
        {
            int currentPage = page < 1 ? 1 : page; 

            var source = _accountSvc.Lookup();

            var result = source.OrderBy(x => x.Date).ToPagedList(currentPage, pageSize);

            return View(result);
        }

        public ActionResult AccountPartialView()
        {
            return PartialView();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}