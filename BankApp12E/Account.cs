using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp12E
{
    internal class Account
    {
        string Name;
        int Balance;

        public Account(string name, int balance)
        {
            Name = name;
            Balance = balance;
        }

        public string Name1 { get => Name; set => Name = value; }
        public int Balance1 { get => Balance; set => Balance = value; }
    }

}
