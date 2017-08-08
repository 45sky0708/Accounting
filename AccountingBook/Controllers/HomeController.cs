using AccountingBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountingBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<AccountingViewModel> AccountData = new List<AccountingViewModel>
            {
                new AccountingViewModel() {Category = "支出", Date = new DateTime(2017,8,5), Amount = 100 },
                new AccountingViewModel() {Category = "收入", Date = new DateTime(2017,8,6), Amount = 250 },
                new AccountingViewModel() {Category = "支出", Date = new DateTime(2017,8,7), Amount = 300 },
                new AccountingViewModel() {Category = "收入", Date = new DateTime(2017,8,8), Amount = 450 },
                new AccountingViewModel() {Category = "支出", Date = new DateTime(2017,8,9), Amount = 600 }
            };
            return View(AccountData);
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