using System.Collections.Generic;

namespace CashMachine.Models
{
    public class CashMachineModel
    {
        public string CurrencySymbol { get; set; }

        public bool isRight { get; set; }

        public List<MoneyModel> Money { get; set; }
    }
}