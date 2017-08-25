using AccountingBook.Models;
using AccountingBook.Repositories;
using AccountingBook.Service;
using AccountingBook.ViewModels;
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

        public ActionResult Index()
        {
            return View();
        }
                
        public ActionResult AccountPartialView(int page = 1)
        {
            int currentPage = page < 1 ? 1 : page;

            var result = _accountSvc.Lookup().OrderBy(x => x.Date).ToPagedList(currentPage, pageSize);

            return PartialView(result);
        }

        [HttpPost]
        public ActionResult Index(AccountingViewModel AccountVM, int page = 1)
        {
            if (ModelState.IsValid)
            {
                _accountSvc.Add(AccountVM);
                _accountSvc.Save();

                return RedirectToAction("Index");
            }
            return View(AccountVM);
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