using FreeAgent.Client;
using FreeAgent.Models;
using NUnit.Framework;
using System;

namespace FreeAgent.Tests
{
    [TestFixture]
    public class ContactFixture : ResourceFixture<ContactWrapper, ContactsWrapper, Contact>
    {
        public override ResourceClient<ContactWrapper, ContactsWrapper, Contact> ResourceClient
        {
            get { return Client.Contact; }
        }

        public override void CheckSingleItem(Contact item)
        {
            Assert.That(item.Url.ToString(), Is.Null.Or.Empty);
            //Assert.That( , Is.Null.Or.Empty);contact.organisation_name);
            //Assert.That( , Is.Null.Or.Empty);contact.first_name);
            //Assert.That( , Is.Null.Or.Empty);contact.last_name);
        }

        public override Contact CreateSingleItemForInsert()
        {
            return new Contact
            {
                //url = "",
                FirstName = "Nic TEST",
                LastName = "Wise",
                OrganisationName = "foo",
                Address1 = DateTime.Now.ToLongTimeString()
            };
        }

        public override void CompareSingleItem(Contact originalItem, Contact newItem)
        {
            Assert.IsNotNull(newItem);
            Assert.That(newItem.Url.ToString(), Is.Null.Or.Empty);
            Assert.AreEqual(newItem.FirstName, originalItem.FirstName);
            Assert.AreEqual(newItem.LastName, originalItem.LastName);
            Assert.AreEqual(newItem.Address1, originalItem.Address1);
        }

        public override bool CanDelete(Contact item)
        {
            return item.FirstName.Contains("TEST");
        }
    }
}
