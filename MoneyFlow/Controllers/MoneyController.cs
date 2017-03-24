using MoneyFlow.Models;
using MoneyFlow.Repositories;
using MoneyFlow.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyFlow.Controllers
{
    public class MoneyController : Controller
    {

        private readonly AccountBookService _accountBookService;
        public MoneyController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountBookService = new AccountBookService(unitOfWork);
        }
        
        public ActionResult Index()
        {
            return View();
        }

        private SkillTreeHomeworkEntities db = new SkillTreeHomeworkEntities();

        public ActionResult AccountingBook()
        {
            return View();
        }

        // POST: Orders/Create，若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(MoneyModel moneyModel)
        {
            if (ModelState.IsValid)
            {                
                var account = new AccountBook();
                account.Id = Guid.NewGuid();
                account.Categoryyy = Convert.ToInt32(moneyModel.Type);
                account.Amounttt = Convert.ToInt32(moneyModel.Money);
                account.Remarkkk = moneyModel.Remark;                
                _accountBookService.Add(account);
                _accountBookService.Save();

                return RedirectToAction("AccountingBook");
            }
            return View(moneyModel);
        }

        [ChildActionOnly]
        public ActionResult MoneyBasicInputForm()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult MoneyList()
        {
            List<MoneyModel> result = GetAllAccountBook();
            return PartialView(result);
        }

        private List<MoneyModel> GetAllAccountBook()
        {
            var accountBooks = _accountBookService.Lookup();
            var result = new List<MoneyModel>();
            foreach (var accountBook in accountBooks)
            {
                result.Add(new MoneyModel()
                {
                    Type = accountBook.Categoryyy == 1 ? "支出" : "收入",
                    Date = accountBook.Dateee,
                    Money = accountBook.Amounttt,
                    Remark = accountBook.Remarkkk
                });
            }
            return result;
        }
    }
}