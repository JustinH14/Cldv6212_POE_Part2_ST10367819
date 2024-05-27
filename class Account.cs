class Account
{
    // Properties
    public string AccountNumber { get; private set; }
    public double Balance { get; private set; }

    // Constructor
    public Account(string accountNumber)
    {
        AccountNumber = accountNumber;
        Balance = 0; // Start with zero balance
    }

    // Methods
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount} into account {AccountNumber}. New balance: ${Balance}");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount. Amount must be greater than zero.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn ${amount} from account {AccountNumber}. New balance: ${Balance}");
        }
        else if (amount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount. Amount must be greater than zero.");
        }
        else
        {
            Console.WriteLine("Insufficient balance for withdrawal.");
        }
    }
}
