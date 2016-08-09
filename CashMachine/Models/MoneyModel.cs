using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashMachine.Models
{
    public class MoneyModel
    {
        public bool isNote { get; set; }

        public string Name { get; set; }

        public double Value { get; set; }

        public int Quantity { get; set; }
    }
}