using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashMachine.Services;
using CashMachine.Repositories;
using CashMachine.DTO;

namespace CashMachine.Tests.Services
{
    [TestClass]
    public class CashMachineServiceTest
    {
        private static MoneyRepository _moneyRepository;
        private static LeastNumberOfItemsService _leastNumberOfItemsService;
        private static Highest20NotesService _highest20NotesService;
        private static CashMachineService _cashMachineService;

        [TestMethod]
        public void CashMachineService_Algorithm1()
        {
            _moneyRepository = new MoneyRepository();
            _leastNumberOfItemsService = new LeastNumberOfItemsService(_moneyRepository);
            _cashMachineService = new CashMachineService(_moneyRepository, _leastNumberOfItemsService);

            var result = _cashMachineService.Withdraw(120);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(WithdrawDTO));

            Assert.IsTrue(result.EnoughCash);
            Assert.AreEqual("£4,518.00", result.Balance);

            Assert.AreEqual(2, result.Withdraw.Count);
            Assert.AreEqual("50", result.Withdraw[0].Name);
            Assert.IsTrue(result.Withdraw[0].isNote);
            Assert.AreEqual(2, result.Withdraw[0].Quantity);

            Assert.AreEqual("20", result.Withdraw[1].Name);
            Assert.IsTrue(result.Withdraw[0].isNote);
            Assert.AreEqual(1, result.Withdraw[1].Quantity);
        }

        [TestMethod]
        public void CashMachineService_Algorithm2()
        {
            _moneyRepository = new MoneyRepository();
            _highest20NotesService = new Highest20NotesService(_moneyRepository);
            _cashMachineService = new CashMachineService(_moneyRepository, _highest20NotesService);

            var result = _cashMachineService.Withdraw(120);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(WithdrawDTO));

            Assert.IsTrue(result.EnoughCash);
            Assert.AreEqual("£4,518.00", result.Balance);

            Assert.AreEqual(1, result.Withdraw.Count);
            Assert.AreEqual("20", result.Withdraw[0].Name);
            Assert.IsTrue(result.Withdraw[0].isNote);
            Assert.AreEqual(6, result.Withdraw[0].Quantity);
        }
    }
}
