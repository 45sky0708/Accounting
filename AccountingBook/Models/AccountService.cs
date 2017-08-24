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
                Category = (Category)x.Categoryyy,
                Amount = x.Amounttt,
                Date = x.Dateee                 
            }).ToList();
            return result;
        }

        public void Add(AccountingViewModel AccountVM)
        {
            var result = new AccountBook()
            {
                Id = Guid.NewGuid(),
                Categoryyy = Convert.ToInt32(AccountVM.Category),
                Amounttt = AccountVM.Amount,
                Dateee = AccountVM.Date,
                Remarkkk = AccountVM.Remark
            };
            _accountRep.Add(result);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}