using Microsoft.AspNetCore.SignalR;

namespace MyApp.Models
{
    public class BankAccount
    {
        private decimal _balance;

        public void Deposit(decimal amount)
        {
            if (amount > 0)
                _balance += amount;
        }

        public decimal GetBalance()
        {
            return _balance;
        }        
    }
}
