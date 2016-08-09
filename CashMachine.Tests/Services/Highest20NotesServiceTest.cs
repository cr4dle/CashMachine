using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashMachine.Services;
using CashMachine.Repositories;
using CashMachine.DTO;

namespace CashMachine.Tests.Services
{
    [TestClass]
    public class Highest20NotesServiceTest
    {
        private static MoneyRepository _moneyRepository;
        private static Highest20NotesService _Highest20NotesService;

        [TestMethod]
        public void Highest20NotesService_Valid()
        {
            _moneyRepository = new MoneyRepository();
            _Highest20NotesService = new Highest20NotesService(_moneyRepository);

            var result = _Highest20NotesService.Withdraw(120);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(WithdrawDTO));

            Assert.IsTrue(result.EnoughCash);

            Assert.AreEqual(1, result.Withdraw.Count);
            Assert.AreEqual("20", result.Withdraw[0].Name);
            Assert.IsTrue(result.Withdraw[0].isNote);
            Assert.AreEqual(6, result.Withdraw[0].Quantity);
        }
    }
}
