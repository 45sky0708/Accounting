using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountingBook.Models
{
    public class AccountingViewModel
    {
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
}