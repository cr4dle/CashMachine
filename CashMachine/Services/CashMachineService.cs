using CashMachine.DTO;
using CashMachine.Interfaces;
using Ninject;
using System;

namespace CashMachine.Services
{
    public class CashMachineService : ICashMachineService
    {
        private IMoneyRepository _moneyRepository;
        private IWithdrawService _withdrawervice;

        // If we change the Named property, we can swap the module
        public CashMachineService(IMoneyRepository moneyRepository, [Named("LeastNumberOfItems")] IWithdrawService withdrawService)
        {
            if (moneyRepository == null) throw new ArgumentNullException(nameof(moneyRepository));
            if (withdrawService == null) throw new ArgumentNullException(nameof(withdrawService));

            _moneyRepository = moneyRepository;
            _withdrawervice = withdrawService;
        }

        public double GetBalance()
        {
            var balance = 0.0d;

            var notes = _moneyRepository.GetAllNotes();
            notes.ForEach(note => balance += note.Quantity * note.Value);

            var coins = _moneyRepository.GetAllCoins();
            coins.ForEach(coin => balance += coin.Quantity * coin.Value);

            return balance;
        }

        public WithdrawDTO Withdraw(double quantity)
        {
            var withdrawDTO = _withdrawervice.Withdraw(quantity);
            withdrawDTO.Balance = GetBalance();

            return withdrawDTO;
        }
    }
}