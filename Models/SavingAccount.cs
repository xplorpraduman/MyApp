namespace MyApp.Models
{

    public  class SavingsAccount : BankAccount
    {
        public void AddInterest()
        {
            Deposit(100); // reuse parent method
        }
    }
}
