using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

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

            Assert.That(item.url, Is.Null.Or.Empty);
            Assert.That(item.type, Is.Null.Or.Empty);
            Assert.That(item.name, Is.Null.Or.Empty);
            Assert.That(item.bank_name, Is.Null.Or.Empty);
        }


        public override BankAccount CreateSingleItemForInsert()
        {
            return new BankAccount
            {
                url = "",
                opening_balance = 100,
                type = BankAccountType.StandardBankAccount,
                name = "Bank Account TEST " + DateTime.Now.ToString(),
                bank_name = "Test Bank"


            };

        }

        public override void CompareSingleItem(BankAccount originalItem, BankAccount newItem)
        {
            Assert.IsNotNull(newItem);
            Assert.That(newItem.url, Is.Null.Or.Empty);
            Assert.AreEqual(newItem.account_number, originalItem.account_number);
            Assert.AreEqual(newItem.type, originalItem.type);
            Assert.AreEqual(newItem.opening_balance, originalItem.opening_balance);
        }

        public override bool CanDelete(BankAccount item)
        {
            return item.name.Contains("TEST");
        }
    }
}
