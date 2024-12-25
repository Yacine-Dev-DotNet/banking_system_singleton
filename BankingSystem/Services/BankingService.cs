namespace BankingSystem.Services
{
    public class BankingService : IBankingService
    {
        private decimal _balance;

        // The constructor receives the configuration to initialize the balance
        public BankingService(IConfiguration configuration)
        {
            var initialBalance = configuration.GetSection("BankingSettings")
                                              .GetValue<decimal>("InitialBalance", 0m);
            _balance = initialBalance;
        }

        public decimal GetBalance() => _balance;

        public bool Withdraw(decimal amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                return true;
            }
            return false;
        }

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }
    }
}
