namespace BankingSystem.Services
{
    public interface IBankingService
    {
        decimal GetBalance();
        bool Withdraw(decimal amount);
        void Deposit(decimal amount);
    }
}
