using CashMachine.DTO;
using CashMachine.Interfaces;
using CashMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CashMachine.Services
{
    public class Highest20NotesService : IWithdrawService
    {
        private IMoneyRepository _moneyRepository;

        public Highest20NotesService(IMoneyRepository moneyRepository)
        {
            if (moneyRepository == null) throw new ArgumentNullException(nameof(moneyRepository));

            _moneyRepository = moneyRepository;
        }

        public WithdrawDTO Withdraw(double quantity)
        {
            var withdrawDTO = new WithdrawDTO {
                EnoughCash = true,
                Withdraw = new List<MoneyModel>()
            };

            var notes = _moneyRepository.GetAllNotes();
            var twentyNotes = notes.Where(note => note.Name == "20").SingleOrDefault();

            if(twentyNotes != null)
            {
                var tempMoney = Check(twentyNotes, quantity);
                if (tempMoney != null)
                {
                    // Deduct the quantity to withdraw
                    quantity -= tempMoney.Value * tempMoney.Quantity;

                    // Add to the return object
                    withdrawDTO.Withdraw.Add(tempMoney);
                    // Withdraw value
                    _moneyRepository.Withdraw(tempMoney);
                }

                if (quantity == 0)
                {
                    return withdrawDTO;
                }
            }

            for(int i=0; i < notes.Count; i++)
            {
                var tempMoney = Check(notes[i], quantity);
                if(tempMoney != null)
                {
                    // Deduct the quantity to withdraw
                    quantity -= tempMoney.Value * tempMoney.Quantity;

                    // Add to the return object
                    withdrawDTO.Withdraw.Add(tempMoney);
                    // Withdraw value
                    _moneyRepository.Withdraw(tempMoney);
                }

                if (quantity == 0)
                {
                    return withdrawDTO;
                }
            }

            var coins = _moneyRepository.GetAllCoins();
            for (int i = 0; i < coins.Count; i++)
            {
                var tempMoney = Check(coins[i], quantity);
                if (tempMoney != null)
                {
                    // Deduct the quantity to withdraw
                    quantity -= tempMoney.Value * tempMoney.Quantity;

                    // Add to the return object
                    withdrawDTO.Withdraw.Add(tempMoney);
                    // Withdraw value
                    _moneyRepository.Withdraw(tempMoney);
                }

                if (quantity == 0)
                {
                    return withdrawDTO;
                }
            }
            
            if(quantity > 0)
            {
                withdrawDTO.EnoughCash = false;
            }

            return withdrawDTO;
        }

        private MoneyModel Check(MoneyModel money, double quantity)
        {
            MoneyModel tempMoneyModel = null;

            if (money.Quantity > 0 && money.Value <= quantity)
            {
                int items = Convert.ToInt32(Math.Truncate(quantity / money.Value));
                if (items > 0)
                {
                    if (money.Quantity >= items)
                    {
                        tempMoneyModel = new MoneyModel
                        {
                            isNote = money.isNote,
                            Name = money.Name,
                            Quantity = items,
                            Value = money.Value
                        };
                    }
                    else
                    {
                        tempMoneyModel = new MoneyModel
                        {
                            isNote = money.isNote,
                            Name = money.Name,
                            Quantity = money.Quantity,
                            Value = money.Value
                        };
                    }
                }
            }

            return tempMoneyModel;
        }
    }
}