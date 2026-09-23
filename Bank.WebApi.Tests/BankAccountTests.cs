using Bank.WebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bank.WebApi.Tests
{
    /// <summary>Contains tests for the bank account model.</summary>
    [TestClass]
    public class BankAccountTests
    {
        /// <summary>Verifies that a valid debit decreases the account balance.</summary>
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        /// <summary>Verifies the account holder and initial balance.</summary>
        [TestMethod]
        public void Constructor_WithInitialValues_SetsAccountProperties()
        {
            var account = new BankAccount("Ada Lovelace", 100.00);

            Assert.AreEqual("Ada Lovelace", account.CustomerName);
            Assert.AreEqual(100.00, account.Balance, 0.001);
        }

        /// <summary>Verifies that a valid credit increases the account balance.</summary>
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            var account = new BankAccount("Ada Lovelace", 10.00);

            account.Credit(7.50);

            Assert.AreEqual(17.50, account.Balance, 0.001);
        }

        /// <summary>Verifies that a negative credit is rejected.</summary>
        [TestMethod]
        public void Credit_WithNegativeAmount_ThrowsException()
        {
            var account = new BankAccount("Ada Lovelace", 10.00);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.Credit(-1.00));
        }

        /// <summary>Verifies that a debit equal to the balance is accepted.</summary>
        [TestMethod]
        public void Debit_UsingEntireBalance_SetsBalanceToZero()
        {
            var account = new BankAccount("Ada Lovelace", 10.00);

            account.Debit(10.00);

            Assert.AreEqual(0.00, account.Balance, 0.001);
        }

        /// <summary>Verifies that a debit greater than the balance is rejected.</summary>
        [TestMethod]
        public void Debit_ExceedingBalance_ThrowsException()
        {
            var account = new BankAccount("Ada Lovelace", 10.00);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(10.01));
        }

        /// <summary>Verifies that a negative debit is rejected.</summary>
        [TestMethod]
        public void Debit_WithNegativeAmount_ThrowsException()
        {
            var account = new BankAccount("Ada Lovelace", 10.00);

            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(-1.00));
        }
    }
}