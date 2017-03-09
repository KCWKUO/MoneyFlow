using MoneyFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyFlow.Controllers
{
    public class MoneyController : Controller
    {
        // GET: Money
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AccountingBook()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult MoneyBasicInputForm()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult MoneyList()
        {
            var money = new List<MoneyModel>()
            {
                new MoneyModel() { Type = "支出", Date = new DateTime(2016, 01, 01), Money = 300 },
                new MoneyModel() { Type = "支出", Date = new DateTime(2016, 01, 02), Money = 1600 },
                new MoneyModel() { Type = "支出", Date = new DateTime(2016, 01, 03), Money = 300 }
            };
            return PartialView(money);
        }

    }
}