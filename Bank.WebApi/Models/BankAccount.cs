namespace Bank.WebApi.Models
{
    /// <summary>
    /// Represents a bank account with a customer name and current balance.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;
        /// <summary>
        /// Creates a bank account with an initial balance.
        /// </summary>
        /// <param name="customerName">Name of the account holder.</param>
        /// <param name="balance">Initial account balance.</param>
        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }
        /// <summary>Gets the name of the account holder.</summary>
        public string CustomerName { get { return m_customerName; } }

        /// <summary>Gets the current account balance.</summary>
        public double Balance { get { return m_balance; }  }

        /// <summary>Withdraws an amount from the account.</summary>
        /// <param name="amount">Non-negative amount to withdraw.</param>
        /// <exception cref="ArgumentOutOfRangeException">The amount is negative or exceeds the balance.</exception>
        public void Debit(double amount)
        {
            if (amount > m_balance)
                throw new ArgumentOutOfRangeException("amount");
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            m_balance -= amount;
        }
        /// <summary>Deposits an amount into the account.</summary>
        /// <param name="amount">Non-negative amount to deposit.</param>
        /// <exception cref="ArgumentOutOfRangeException">The amount is negative.</exception>
        public void Credit(double amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException("amount");
            m_balance += amount;
        }
    }
}