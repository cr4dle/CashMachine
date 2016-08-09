using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashMachine.Services;
using CashMachine.Repositories;
using CashMachine.DTO;

namespace CashMachine.Tests.Services
{
    [TestClass]
    public class LeastNumberOfItemsServiceTest
    {
        private static MoneyRepository _moneyRepository;
        private static LeastNumberOfItemsService _leastNumberOfItemsService;

        [TestMethod]
        public void LeastNumberOfItemsService_Valid()
        {
            _moneyRepository = new MoneyRepository();
            _leastNumberOfItemsService = new LeastNumberOfItemsService(_moneyRepository);

            var result = _leastNumberOfItemsService.Withdraw(120);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(WithdrawDTO));

            Assert.IsTrue(result.EnoughCash);

            Assert.AreEqual(2, result.Withdraw.Count);
            Assert.AreEqual("50", result.Withdraw[0].Name);
            Assert.IsTrue(result.Withdraw[0].isNote);
            Assert.AreEqual(2, result.Withdraw[0].Quantity);

            Assert.AreEqual("20", result.Withdraw[1].Name);
            Assert.IsTrue(result.Withdraw[0].isNote);
            Assert.AreEqual(1, result.Withdraw[1].Quantity);
        }
    }
}
