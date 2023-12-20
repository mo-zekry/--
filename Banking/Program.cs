namespace Banking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Account account = new Account("John Doe", 1000);

            MenuOption selectedOption = Account.ReadUserOption();

            switch (selectedOption)
            {
                case MenuOption.Deposit:
                    decimal depositAmount = PromptForAmount("Enter the amount to deposit: ");
                    account.Deposit(depositAmount);
                    account.Print();
                    break;
                case MenuOption.Withdraw:
                    decimal withdrawAmount = PromptForAmount("Enter the amount to withdraw: ");
                    account.Withdraw(withdrawAmount);
                    account.Print();
                    break;
                case MenuOption.Print:
                    account.Print();
                    break;
                case MenuOption.Quit:
                    Console.WriteLine("Exiting the program...");
                    return;
            }
        }

        private static decimal PromptForAmount(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    return amount;
                }
                Console.WriteLine("Invalid input, please enter a valid decimal number.");
            }
        }
    }
}
