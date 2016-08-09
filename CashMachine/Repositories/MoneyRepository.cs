using CashMachine.Interfaces;
using CashMachine.Models;
using System.Collections.Generic;
using System.Linq;

namespace CashMachine.Repositories
{
    public class MoneyRepository : IMoneyRepository
    {
        private readonly CashMachineModel _cashMachine;

        public MoneyRepository()
        {
            // Mock the DB
            _cashMachine = new CashMachineModel
            {
                CurrencySymbol = "£",
                isRight = true,
                Money = new List<MoneyModel>
                {
                    new MoneyModel
                    {
                        isNote = true,
                        Name = "50",
                        Value = 50,
                        Quantity = 50
                    },
                    new MoneyModel
                    {
                        isNote = true,
                        Name = "20",
                        Value = 20,
                        Quantity = 50
                    },
                    new MoneyModel
                    {
                        isNote = true,
                        Name = "10",
                        Value = 10,
                        Quantity = 50
                    },
                    new MoneyModel
                    {
                        isNote = true,
                        Name = "5",
                        Value = 5,
                        Quantity = 50
                    },
                    new MoneyModel
                    {
                        isNote = false,
                        Name = "2",
                        Value = 2,
                        Quantity = 100
                    },
                    new MoneyModel
                    {
                        isNote = false,
                        Name = "1",
                        Value = 1,
                        Quantity = 100
                    },
                    new MoneyModel
                    {
                        isNote = false,
                        Name = "50",
                        Value = 0.50,
                        Quantity = 100
                    },
                    new MoneyModel
                    {
                        isNote = false,
                        Name = "20",
                        Value = 0.20,
                        Quantity = 100
                    },
                    new MoneyModel
                    {
                        isNote = false,
                        Name = "10",
                        Value = 0.10,
                        Quantity = 100
                    },
                    new MoneyModel
                    {
                        isNote = false,
                        Name = "5",
                        Value = 0.05,
                        Quantity = 100
                    },
                    new MoneyModel
                    {
                        isNote = false,
                        Name = "2",
                        Value = 0.02,
                        Quantity = 100
                    },
                    new MoneyModel
                    {
                        isNote = false,
                        Name = "1",
                        Value = 0.01,
                        Quantity = 100
                    }
                }
            };
        }

        /// <summary>
        /// It will be used to display the currency symbol
        /// </summary>
        /// <returns></returns>
        public CashMachineModel GetAll()
        {
            return _cashMachine;
        }

        /// <summary>
        /// Returns all the coins
        /// </summary>
        /// <returns>Returns the coins with descending order</returns>
        public List<MoneyModel> GetAllCoins()
        {
            var onlyCoins = _cashMachine.Money.Where(x => !x.isNote).OrderBy(x=>x.Value).ToList();

            return onlyCoins;
        }

        /// <summary>
        /// Returns all the notes
        /// </summary>
        /// <returns>Returns the notes with descending order</returns>
        public List<MoneyModel> GetAllNotes()
        {
            var onlyNotes = _cashMachine.Money.Where(x => x.isNote).OrderBy(x => x.Value).ToList();

            return onlyNotes;
        }

        /// <summary>
        /// Deduct the quantity taken
        /// </summary>
        /// <param name="money"></param>
        public void Withdraw(MoneyModel money)
        {
            var dbMoney = _cashMachine.Money.Where(x => x.Name == money.Name).SingleOrDefault();
            
            //It should exists always
            if(dbMoney != null)
            {
                dbMoney.Quantity -= money.Quantity;
            }
        }
    }
}