using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

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

            Assert.That(item.url, Is.Null.Or.Empty);
            //Assert.That( , Is.Null.Or.Empty);contact.organisation_name);
            //Assert.That( , Is.Null.Or.Empty);contact.first_name);
            //Assert.That( , Is.Null.Or.Empty);contact.last_name);
        }


        public override Contact CreateSingleItemForInsert()
        {
            return new Contact
            {
                url = "",
                first_name = "Nic TEST",
                last_name = "Wise",
                organisation_name = "foo",
                address1 = DateTime.Now.ToLongTimeString()
            };

        }

        public override void CompareSingleItem(Contact originalItem, Contact newItem)
        {
            Assert.IsNotNull(newItem);
            Assert.That(newItem.url, Is.Null.Or.Empty);
            Assert.AreEqual(newItem.first_name, originalItem.first_name);
            Assert.AreEqual(newItem.last_name, originalItem.last_name);
            Assert.AreEqual(newItem.address1, originalItem.address1);
        }

        public override bool CanDelete(Contact item)
        {
            return item.first_name.Contains("TEST");

        }
        

        
    }
}
