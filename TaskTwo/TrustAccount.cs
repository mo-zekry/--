namespace TaskTwo
{
    public class TrustAccount : SavingsAccount
    {
        private const double BonusThreshold = 5000.0;
        private const double BonusAmount = 50.0;
        private const int MaxWithdrawalsPerYear = 3;
        private const double MaxWithdrawalPercentage = 0.20;

        private int withdrawalsThisYear;

        public TrustAccount(string name = "Unnamed Trust Account", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance, interestRate)
        {
            withdrawalsThisYear = 0;
        }

        // Override Deposit to handle bonus
        public override bool Deposit(double amount)
        {
            if (base.Deposit(amount))   
            {
                if (amount >= BonusThreshold)
                {
                    balance += BonusAmount;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        // Override Withdraw to limit the number and amount of withdrawals
        public override bool Withdraw(double amount)
        {
            if (withdrawalsThisYear < MaxWithdrawalsPerYear && amount <= balance * MaxWithdrawalPercentage)
            {
                withdrawalsThisYear++;
                return base.Withdraw(amount);
            }
            else
            {
                return false;
            }
        }
    }
}

