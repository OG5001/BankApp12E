namespace BankApp12E
{
    public class Bank
    {
        Dictionary<string, Account> accounts = new Dictionary<string, Account>();

        public void CreateAccount(string account, string name)
        {
            accounts.Add(account, new Account(name, 0));
        }

        public int GetBalance(string account)
        {
            if (!accounts.ContainsKey(account))
            {
                throw new ArgumentException("Invalid account");
            }
            return accounts[account].Balance1;
        }

        public void Deposit(string account, int amount)
        {
            if (!accounts.ContainsKey(account))
            {
                throw new ArgumentException("Invalid account");
            }

            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }
            accounts[account].Balance1 += amount;
        }

        public bool Withdraw(string account, int amount)
        {
            if (!accounts.ContainsKey(account))
            {
                throw new ArgumentException("Invalid account");
            }
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }
            if (accounts[account].Balance1 < amount)
            {
                return false;
            }
            accounts[account].Balance1 -= amount;
            return true;
        }

        public bool Transfer(string fromAccount, string toAccount, int amount)
        {
            if (!accounts.ContainsKey(fromAccount) || !accounts.ContainsKey(toAccount))
            {
                throw new ArgumentException("Invalid account");
            }
            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }
            if (accounts[fromAccount].Balance1 < amount)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
            accounts[fromAccount].Balance1 -= amount;
            accounts[toAccount].Balance1 += amount;
            return true;
        }

        public bool CloseAccount(string account, int amount)
        {
            if (!accounts.ContainsKey(account))
            {
                throw new ArgumentException("Invalid account");
            }
            if (amount < 0)
            {
                throw new InvalidOperationException("Amount must be 0");
            }
            if (amount > 0)
            {
                throw new InvalidOperationException("Amount must be 0");
            }
            accounts.Remove(account);
            return true;
        }

        public string GetOwner(string account)
        {
            if (!accounts.ContainsKey(account))
            {
                throw new ArgumentException("Invalid account");
            }
            return accounts[account].Name1;
        }
    }
}
