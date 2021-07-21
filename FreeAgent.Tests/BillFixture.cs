using FreeAgent.Client;
using FreeAgent.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FreeAgent.Tests
{
    [TestFixture]
    public class BillFixture : ResourceFixture<BillWrapper, BillsWrapper, Bill>
    {
        public override void SetupClient()
        {
            base.SetupClient();
            GetAll = BillAll;
        }

        public IEnumerable<Bill> BillAll()
        {
            return Client.Bill.All(/*view: "recent"*/);
        }

        public override ResourceClient<BillWrapper, BillsWrapper, Bill> ResourceClient
        {
            get { return Client.Bill; }
        }

        public override void CheckSingleItem(Bill item)
        {
            Assert.That(item.Url.ToString(), Is.Null.Or.Empty);
            //Assert.That( , Is.Null.Or.Empty);contact.organisation_name);
            //Assert.That( , Is.Null.Or.Empty);contact.first_name);
            //Assert.That( , Is.Null.Or.Empty);contact.last_name);
        }

        public override Bill CreateSingleItemForInsert()
        {
            Assert.Ignore("IGNORING Bill INSERTING UNTIL IT WORKS");
            var user = Client.User.Me;
            var cat = Client.Category.Single("250");

            return new Bill
            {
                //url = "",
                DatedOn = DateTime.Now,
                //category = cat.UrlId(),
                //recurring = false
            };
        }

        public override void CompareSingleItem(Bill originalItem, Bill newItem)
        {
            Assert.IsNotNull(newItem);
            Assert.That(newItem.Url.ToString(), Is.Null.Or.Empty);
            Assert.AreEqual(newItem.Status, originalItem.Status);
            //Assert.AreEqual(newItem.user, originalItem.user);
            Assert.AreEqual(newItem.DatedOn, originalItem.DatedOn);
        }

        public override bool CanDelete(Bill item)
        {
            return false;
            return item.Status.Contains("TEST");
        }
    }
}
