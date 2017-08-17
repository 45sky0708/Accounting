using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AccountingBook.Models;
using AccountingBook.Repositories;
using AccountingBook.ViewModels;

namespace AccountingBook.Service
{
    public class AccountService
    {
        private readonly IRepository<AccountBook> _accountRep;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _accountRep = new Repository<AccountBook>(unitOfWork);
        }

        public IEnumerable<AccountingViewModel> Lookup()
        {
            var source = _accountRep.LookupAll();
            var result = source.Select(x => new AccountingViewModel()
            {
                Category = x.Categoryyy == 0 ? "收入" : "支出",
                Amount = x.Amounttt,
                Date = x.Dateee                 
            }).ToList();
            return result;
        }        
    }
}