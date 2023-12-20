namespace TaskTwo
{
    public class CheckingAccount : Account
    {
        private const double WithdrawalFee = 1.50;

        public CheckingAccount(string name = "Unnamed Checking Account", double balance = 0.0)
            : base(name, balance)
        {
        }

        // Override Withdraw to include the withdrawal fee
        public override bool Withdraw(double amount)
        {
            if (base.Withdraw(amount))
            {
                balance -= WithdrawalFee;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

