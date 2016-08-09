using CashMachine.DTO;

namespace CashMachine.Interfaces
{
    public interface IWithdrawService
    {
        WithdrawDTO Withdraw(double quantity);
    }
}
