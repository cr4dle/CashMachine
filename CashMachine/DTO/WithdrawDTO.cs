using CashMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashMachine.DTO
{
    public class WithdrawDTO
    {
        public bool EnoughCash{ get; set; }

        public double Balance { get; set; }

        public List<MoneyModel> Withdraw { get; set; }
    }
}