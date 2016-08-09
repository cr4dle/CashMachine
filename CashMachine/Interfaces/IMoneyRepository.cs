using CashMachine.Models;
using System.Collections.Generic;

namespace CashMachine.Interfaces
{
    public interface IMoneyRepository
    {
        CashMachineModel GetAll();
        List<MoneyModel> GetAllNotes();
        List<MoneyModel> GetAllCoins();
        void Withdraw(MoneyModel money);
    }
}
