using CashMachine.DTO;
using CashMachine.Interfaces;
using System;
using System.Web.Http;

namespace CashMachine.Controllers
{
    public class WithdrawController : ApiController
    {
        private ICashMachineService _cashMachineService;

        public WithdrawController(ICashMachineService cashMachineService)
        {
            if (cashMachineService == null) throw new ArgumentNullException(nameof(cashMachineService));

            _cashMachineService = cashMachineService;
        }

        // GET: api/Withdraw/120
        public WithdrawDTO Get(double quantity)
        {
            var debug = _cashMachineService.Withdraw(quantity);
            return debug;
        }
    }
}
