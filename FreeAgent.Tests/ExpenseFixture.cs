//using FreeAgent.Client;
//using FreeAgent.Models;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;

//namespace FreeAgent.Tests
//{
//    [TestFixture]
//    public class ExpenseFixture : ResourceFixture<ExpenseWrapper, ExpensesWrapper, Expense>
//    {
//        public override void SetupClient()
//        {
//            base.SetupClient();
//            GetAll = ExpenseAll;
//        }

//        public IEnumerable<Expense> ExpenseAll()
//        {
//            return Client.Expense.All(view: "recent");
//        }

//        public override ResourceClient<ExpenseWrapper, ExpensesWrapper, Expense> ResourceClient
//        {
//            get { return Client.Expense; }
//        }

//        public override void CheckSingleItem(Expense item)
//        {
//            Assert.That(item.Url.ToString(), Is.Null.Or.Empty);
//            //Assert.That( , Is.Null.Or.Empty);contact.organisation_name);
//            //Assert.That( , Is.Null.Or.Empty);contact.first_name);
//            //Assert.That( , Is.Null.Or.Empty);contact.last_name);
//        }

//        public override Expense CreateSingleItemForInsert()
//        {
//            Assert.Ignore("IGNORING EXPENSE INSERTING UNTIL IT WORKS");
//            var user = Client.User.Me;
//            var cat = Client.Category.Single("250");

//            return new Expense
//            {
//                //url = "",
//                //User = user.UrlId(),
//                GrossValue = 100M,
//                Description = "Expense TEST",
//                DatedOn = DateTime.Now,
//                //category = cat.UrlId(),
//                //recurring = false
//            };
//        }

//        public override void CompareSingleItem(Expense originalItem, Expense newItem)
//        {
//            Assert.IsNotNull(newItem);
//            Assert.That(newItem.Url.ToString(), Is.Null.Or.Empty);
//            Assert.AreEqual(newItem.Description, originalItem.Description);
//            //Assert.AreEqual(newItem.user, originalItem.user);
//            Assert.AreEqual(newItem.DatedOn, originalItem.DatedOn);
//        }

//        public override bool CanDelete(Expense item)
//        {
//            return false;
//            return item.Description.Contains("TEST");
//        }
//    }
//}
