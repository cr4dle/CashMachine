using CashMachine.DTO;
using CashMachine.Interfaces;
using CashMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CashMachine.Services
{
    public class LeastNumberOfItemsService : IWithdrawService
    {
        private IMoneyRepository _moneyRepository;

        public LeastNumberOfItemsService(IMoneyRepository moneyRepository)
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
            for(int i=0; i < notes.Count; i++)
            {
                if (notes[i].Quantity > 0)
                {
                    int items = Convert.ToInt32(quantity / notes[i].Value);
                    if (items > 0)
                    {
                        if (notes[i].Quantity >= items)
                        {
                            var tempMoneyToWithdraw = new MoneyModel
                            {
                                isNote = notes[i].isNote,
                                Name = notes[i].Name,
                                Quantity = items,
                                Value = notes[i].Value
                            };

                            // Deduct the quantity to withdraw
                            quantity -= notes[i].Value * items;

                            // Add to the return object
                            withdrawDTO.Withdraw.Add(tempMoneyToWithdraw);
                            // Withdraw value
                            _moneyRepository.Withdraw(tempMoneyToWithdraw);
                        }
                        else
                        {
                            var tempMoneyToWithdraw = new MoneyModel
                            {
                                isNote = notes[i].isNote,
                                Name = notes[i].Name,
                                Quantity = notes[i].Quantity,
                                Value = notes[i].Value
                            };

                            // Deduct the quantity to withdraw
                            quantity -= notes[i].Value * notes[i].Quantity;

                            // Add to the return object
                            withdrawDTO.Withdraw.Add(tempMoneyToWithdraw);
                            // Withdraw value
                            _moneyRepository.Withdraw(tempMoneyToWithdraw);
                        }

                        if (quantity == 0)
                        {
                            return withdrawDTO;
                        }
                    }
                }
            }

            var coins = _moneyRepository.GetAllCoins();
            for (int i = 0; i < coins.Count; i++)
            {
                if (coins[i].Quantity > 0)
                {
                    int items = Convert.ToInt32(quantity / coins[i].Value);
                    if (items > 0)
                    {
                        if (coins[i].Quantity >= items)
                        {
                            var tempMoneyToWithdraw = new MoneyModel
                            {
                                isNote = coins[i].isNote,
                                Name = coins[i].Name,
                                Quantity = items,
                                Value = coins[i].Value
                            };

                            // Deduct the quantity to withdraw
                            quantity -= coins[i].Value * items;

                            // Add to the return object
                            withdrawDTO.Withdraw.Add(tempMoneyToWithdraw);
                            // Withdraw value
                            _moneyRepository.Withdraw(tempMoneyToWithdraw);
                        }
                        else
                        {
                            var tempMoneyToWithdraw = new MoneyModel
                            {
                                isNote = coins[i].isNote,
                                Name = coins[i].Name,
                                Quantity = coins[i].Quantity,
                                Value = coins[i].Value
                            };

                            // Deduct the quantity to withdraw
                            quantity -= coins[i].Value * coins[i].Quantity;

                            // Add to the return object
                            withdrawDTO.Withdraw.Add(tempMoneyToWithdraw);
                            // Withdraw value
                            _moneyRepository.Withdraw(tempMoneyToWithdraw);
                        }

                        if (quantity == 0)
                        {
                            return withdrawDTO;
                        }
                    }
                }
            }
            
            if(quantity > 0)
            {
                withdrawDTO.EnoughCash = false;
            }

            return withdrawDTO;
        }
    }
}