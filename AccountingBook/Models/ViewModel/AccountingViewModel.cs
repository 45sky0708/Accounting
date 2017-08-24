using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountingBook.ViewModels
{
    public class AccountingViewModel
    {

        [Display(Name = "類別")]
        [Required(ErrorMessage = "{0}為必填欄位")]
        public Category Category { get; set; }

        [Display(Name = "日期")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "{0}為必填欄位")]
        [Remote("DateValidate", "Validate", ErrorMessage = "{0}不得大於今天日期")]
        public DateTime Date { get; set; }

        [Display(Name = "金額")]
        [Required(ErrorMessage = "{0}為必填欄位")]
        [Range(1, Int32.MaxValue, ErrorMessage = "{}只能是正整數")]
        public int Amount { get; set; }

        [Display(Name = "備註")]
        [Required(ErrorMessage = "{0}為必填欄位")]
        [StringLength(100, ErrorMessage = "{0}不能超過{}個字")]
        public string Remark { get; set; }
    }

    public enum Category
    {
        [Display(Name = "支出")]
        Expend,
        [Display(Name = "收入")]
        Income
    }
}