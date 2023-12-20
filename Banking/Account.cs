namespace Banking
{
    /// <summary>
    /// Represents a bank account with basic transaction operations.
    /// </summary>
    public class Account
    {
        private decimal _balance;
        private readonly string _name;

        /// <summary>
        /// Initializes a new instance of the Account class with a specified name and initial balance.
        /// </summary>
        /// <param name="name">The name of the account holder.</param>
        /// <param name="balance">The initial balance of the account.</param>
        public Account(string name, decimal balance)
        {
            _name = name;
            _balance = balance;
        }

        /// <summary>
        /// Gets the current balance of the account.
        /// </summary>
        public decimal Balance { get { return _balance; } }

        /// <summary>
        /// Gets the name of the account holder.
        /// </summary>
        public string Name { get { return _name; } }

        /// <summary>
        /// Deposits a specified amount into the account.
        /// </summary>
        /// <param name="amount">The amount to deposit.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the amount is less than or equal to zero.</exception>
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
            }
            _balance += amount;
        }

        /// <summary>
        /// Withdraws a specified amount from the account.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the amount is less than or equal to zero.</exception>
        /// <exception cref="InvalidOperationException">Thrown when there are insufficient funds for the withdrawal.</exception>
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
            }

            if (_balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds for withdrawal.");
            }

            _balance -= amount;
        }

        /// <summary>
        /// Prints the current balance of the account to the console.
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Balance for {_name} is {_balance}");
        }

        /// <summary>
        /// Reads the user's menu option selection from the console.
        /// </summary>
        /// <returns>The selected menu option.</returns>
        public static MenuOption ReadUserOption()
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Print");
            Console.WriteLine("4. Quit");
            do
            {
                Console.Write("enter an option between 1 and 4: ");

                if (int.TryParse(Console.ReadLine(), out int input))
                {
                    switch (input)
                    {
                        case 1:
                            return MenuOption.Deposit;
                        case 2:
                            return MenuOption.Withdraw;
                        case 3:
                            return MenuOption.Print;
                        case 4:
                            return MenuOption.Quit;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter an integer.");
                }
            } while (true);
        }
    }

}