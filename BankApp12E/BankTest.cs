using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp12E
{
    [TestFixture]
    public class BankTest
    {
        Bank bank;

        [SetUp]
        public void SetUp()
        {
            bank = new Bank();
            bank.CreateAccount("1234");
        }

        [Test]
        public void StartingBalanceIsZero()
        {
            Assert.That(bank.GetBalance("1234"), Is.Zero);
        }

        [Test]
        public void DepositOnce()
        {
            bank.Deposit("1234", 10000);
            Assert.That(bank.GetBalance("1234"), Is.EqualTo(10000));
        }

        [Test]
        public void DepositMultiple()
        {
            bank.Deposit("1234", 10000);
            bank.Deposit("1234", 15000);
            Assert.That(bank.GetBalance("1234"), Is.EqualTo(25000));
        }

        [Test]
        public void DepositNegativeAmount()
        {
            
            Assert.That(() => bank.Deposit("1234", -10000), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void DepositMultipleAccounts()
        {
            bank.CreateAccount("5678");
            bank.Deposit("1234", 10000);
            Assert.That(bank.GetBalance("1234"), Is.EqualTo(10000));
            Assert.That(bank.GetBalance("5678"), Is.Zero);
        }

        [Test]
        public void GetBalanceOfInvalidAccount()
        {
            Assert.That(() => bank.GetBalance("5678"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void DepositToInvalidAccount()
        {
            Assert.That(() => bank.Deposit("5678", 5000), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void Withdraw()
        {
            bank.Deposit("1234", 10000);
            Assert.That(bank.Withdraw("1234", 5000), Is.True);
            Assert.That(bank.GetBalance("1234"), Is.EqualTo(5000));
        }
        public void WithdrawFromInvalidAccount()
        {
            Assert.That(() => bank.Withdraw("5678", 500), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void WithdrawTooMuch()
        {
            bank.Deposit("1234", 10000);
            Assert.That(bank.Withdraw("1234", 15000), Is.False);
            Assert.That(bank.GetBalance("1234"), Is.EqualTo(10000));
        }
        [Test]
        public void WithdrawNegativeAmount()
        {
            Assert.That(() => bank.Withdraw("1234", -5000), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void TransferMoney()
        {
            bank.CreateAccount("9876");
            bank.Deposit("9876", 10000);
            bank.Deposit("1234", 10000);
            Assert.That(bank.Transfer("1234", "9876", 10000), Is.True);
            Assert.That(bank.GetBalance("1234"), Is.EqualTo(0));

        }
        [Test]
        public void TransferNegativeAmount()
        {
            bank.CreateAccount("9876");
            bank.Deposit("9876", 10000);
            bank.Deposit("1234", 10000);
            Assert.That(() => bank.Transfer("1234", "9876", -10000), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TransferTooMuch()
        {
            bank.CreateAccount("9876");
            bank.Deposit("9876", 10000);
            bank.Deposit("1234", 10000);
            Assert.That(() => bank.Transfer("1234", "9876", 15000), Throws.TypeOf<InvalidOperationException>());
            Assert.That(bank.GetBalance("1234"), Is.EqualTo(10000));
        }
        [Test]
        public void TransferFromInvalidAccount()
        {
            bank.CreateAccount("9876");
            bank.Deposit("9876", 10000);
            Assert.That(() => bank.Transfer("3333", "9876", 5000), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void DeleteAccount()
        {
            bank.CreateAccount("9876");
            bank.Deposit("9876", 10000);
            bank.Withdraw("9876", 10000);
            Assert.That(bank.CloseAccount("9876", bank.GetBalance("9876")), Is.True);
            Assert.That(() => bank.GetBalance("9876"), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void DeleteAccountInvalidBalance()
        {
            bank.CreateAccount("9876");
            bank.Deposit("9876", 10000);
            Assert.That(() => bank.CloseAccount("9876", bank.GetBalance("9876")), Throws.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void DeleteAccountInvalidAccount()
        {
            Assert.That(() => bank.CloseAccount("2222", 0), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void DeleteAccountNegativeBalance()
        {
            bank.CreateAccount("9876");
            Assert.That(() => bank.CloseAccount("9876", -10000), Throws.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void DeleteAccountPositiveBalance()
        {
            bank.CreateAccount("9876");
            bank.Deposit("9876", 10000);
            Assert.That(() => bank.CloseAccount("9876", bank.GetBalance("9876")), Throws.TypeOf<InvalidOperationException>());
        }
    }
}
