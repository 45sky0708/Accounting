using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountingBook.Controllers
{
    public class ValidateController : Controller
    {
        public ActionResult DateValidate(string Date)
        {
            bool isValidate = Convert.ToDateTime(Date) <= DateTime.Today;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}