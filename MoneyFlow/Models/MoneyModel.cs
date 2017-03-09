using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyFlow.Models
{
    public class MoneyModel
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public decimal Money { get; set; }
    }
}