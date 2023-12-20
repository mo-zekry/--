namespace TaskTwo
{
    public class SavingsAccount : Account
    {
        protected double interestRate;

        public SavingsAccount(string name = "Unnamed Savings Account", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance)
        {
            this.interestRate = interestRate;
        }

        // Additional helper function for SavingsAccount
        public double GetInterestRate()
        {
            return interestRate;
        }
    }
}

