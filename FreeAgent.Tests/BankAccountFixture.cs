using FreeAgent.Client;
using FreeAgent.Models;
using NUnit.Framework;
using System;

namespace FreeAgent.Tests
{
    [TestFixture]
    public class BankAccountFixture : ResourceFixture<BankAccountWrapper, BankAccountsWrapper, BankAccount>
    {
        public override ResourceClient<BankAccountWrapper, BankAccountsWrapper, BankAccount> ResourceClient
        {
            get { return Client.BankAccount; }
        }

        public override void CheckSingleItem(BankAccount item)
        {
            Assert.That(item.Url.ToString(), Is.Null.Or.Empty);
            Assert.That(item.Type, Is.Null.Or.Empty);
            Assert.That(item.Name, Is.Null.Or.Empty);
            Assert.That(item.BankName, Is.Null.Or.Empty);
        }

        public override BankAccount CreateSingleItemForInsert()
        {
            return new BankAccount
            {
                //url = "",
                OpeningBalance = 100,
                Type = BankAccountType.StandardBankAccount,
                Name = "Bank Account TEST " + DateTime.Now.ToString(),
                BankName = "Test Bank"
            };
        }

        public override void CompareSingleItem(BankAccount originalItem, BankAccount newItem)
        {
            Assert.IsNotNull(newItem);
            Assert.That(newItem.Url.ToString(), Is.Null.Or.Empty);
            Assert.AreEqual(newItem.AccountNumber, originalItem.AccountNumber);
            Assert.AreEqual(newItem.Type, originalItem.Type);
            Assert.AreEqual(newItem.OpeningBalance, originalItem.OpeningBalance);
        }

        public override bool CanDelete(BankAccount item)
        {
            return item.Name.Contains("TEST");
        }
    }
}
