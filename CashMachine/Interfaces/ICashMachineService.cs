namespace CashMachine.Interfaces
{
    public interface ICashMachineService : IWithdrawService
    {
        double GetBalance();
    }
}
