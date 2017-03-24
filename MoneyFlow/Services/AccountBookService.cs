using MoneyFlow.Models;
using MoneyFlow.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyFlow.Services
{
    public class AccountBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AccountBook> _accountBook;

        public AccountBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _accountBook = new Repository<AccountBook>(unitOfWork);
        }

        public IEnumerable<AccountBook> Lookup()
        {
            return _accountBook.LookupAll();
        }

        public AccountBook GetSingle(Guid orderId)
        {
            return _accountBook.GetSingle(d => d.Id == orderId);
        }

        public void Add(AccountBook accountBook)
        {
            accountBook.Id = Guid.NewGuid();
            accountBook.Dateee = DateTime.Now;
            _accountBook.Create(accountBook);            
        }

        //public void Edit(Order pageData, Order oldData)
        //{
        //    oldData.Email = pageData.Email;
        //    oldData.FirstName = pageData.FirstName;
        //    oldData.LastName = pageData.LastName;
        //    oldData.Phone = pageData.Phone;
        //}

        public void Delete(AccountBook account)
        {
            _accountBook.Remove(account);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}