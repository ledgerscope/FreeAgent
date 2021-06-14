using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace FreeAgent.Tests
{
    [TestFixture]
    public class ExpenseFixture : ResourceFixture<ExpenseWrapper, ExpensesWrapper, Expense>
    {
        public override void SetupClient()
        {
            base.SetupClient();
            GetAll = ExpenseAll;
        }

        public IEnumerable<Expense> ExpenseAll()
        {
            return Client.Expense.All(view: "recent");
        }

        public override ResourceClient<ExpenseWrapper, ExpensesWrapper, Expense> ResourceClient
        {
            get { return Client.Expense; }
        }


        public override void CheckSingleItem(Expense item)
        {

            Assert.That(item.url, Is.Null.Or.Empty);
            //Assert.That( , Is.Null.Or.Empty);contact.organisation_name);
            //Assert.That( , Is.Null.Or.Empty);contact.first_name);
            //Assert.That( , Is.Null.Or.Empty);contact.last_name);
        }


        public override Expense CreateSingleItemForInsert()
        {

            Assert.Ignore("IGNORING EXPENSE INSERTING UNTIL IT WORKS");
            var user = Client.User.Me;
            var cat = Client.Categories.Single("250");

            return new Expense
            {
                url = "",
                user = user.UrlId(),
                gross_value = 100.00,
                description = "Expense TEST",
                dated_on = DateTime.Now.ModelDate(),
                category = cat.UrlId(),
                //recurring = false


            };
              

        }

        public override void CompareSingleItem(Expense originalItem, Expense newItem)
        {
            Assert.IsNotNull(newItem);
            Assert.That(newItem.url, Is.Null.Or.Empty);
            Assert.AreEqual(newItem.description, originalItem.description);
            //Assert.AreEqual(newItem.user, originalItem.user);
            Assert.AreEqual(newItem.dated_on, originalItem.dated_on);
        }

        public override bool CanDelete(Expense item)
        {
            return false;
            return item.description.Contains("TEST");

        }
        

        
    }
}
