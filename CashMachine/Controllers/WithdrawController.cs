using CashMachine.DTO;
using CashMachine.Interfaces;
using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace CashMachine.Controllers
{
    [EnableCors(origins: "http://localhost:20361", headers: "*", methods: "*")]
    public class WithdrawController : ApiController
    {
        private ICashMachineService _cashMachineService;

        public WithdrawController(ICashMachineService cashMachineService)
        {
            if (cashMachineService == null) throw new ArgumentNullException(nameof(cashMachineService));

            _cashMachineService = cashMachineService;
        }

        // GET: api/Withdraw/120.50/
        public HttpResponseMessage Get(double quantity)
        {
            var withdrawDetails = _cashMachineService.Withdraw(quantity);

            var jsonData = new JavaScriptSerializer().Serialize(withdrawDetails);

            return JsonResponse.Create(Request, jsonData);
        }
    }
}
