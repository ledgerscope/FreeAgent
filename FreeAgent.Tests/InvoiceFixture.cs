//using FreeAgent.Client;
//using FreeAgent.Extensions;
//using FreeAgent.Models;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;

//namespace FreeAgent.Tests
//{
//    [TestFixture]
//    public class InvoiceFixture : ResourceFixture<InvoiceWrapper, InvoicesWrapper, Invoice>
//    {
//        public override void Configure()
//        {
//            base.Configure();
//            ExecuteCanGetListWithContent = false;
//        }

//        [Test]
//        public void CanGetListWithSingleCall()
//        {
//            var list = Client.Invoice.AllWithFilter(InvoiceViewFilter.RecentOpenOrOverdue);

//            CheckAllList(list);

//            foreach (var item in list)
//            {
//                CheckSingleItem(item);
//            }
//        }

//        [Test]
//        public void CanGetListForProject()
//        {
//            var project = Client.Project.All()[0];

//            var list = Client.Invoice.AllForProject(project.UrlId());

//            CheckAllList(list);

//            foreach (var item in list)
//            {
//                CheckSingleItem(item);
//            }
//        }

//        [Test]
//        public void CanGetListForContact()
//        {
//            var contact = Client.Contact.All()[0];

//            var list = Client.Invoice.AllForContact(contact.UrlId());

//            CheckAllList(list);

//            foreach (var item in list)
//            {
//                CheckSingleItem(item);
//            }
//        }

//        public override ResourceClient<InvoiceWrapper, InvoicesWrapper, Invoice> ResourceClient
//        {
//            get { return Client.Invoice; }
//        }

//        public override void CheckSingleItem(Invoice item)
//        {
//            Assert.That(item.Url, Is.Null.Or.Empty);
//            Assert.IsNotEmpty(item.InvoiceItems);
//        }

//        public override Invoice CreateSingleItemForInsert()
//        {
//            var contact = Client.Contact.All()[0];

//            Assert.IsNotNull(contact);

//            //find a project for this contact

//            var items = new List<InvoiceItem>
//            {
//                new InvoiceItem
//                {
//                    ItemType = InvoiceItemType.Products,
//                    Quantity = 1,
//                    Price = 100M,
//                    Description = "some item TEST"
//                }
//            };

//            return new Invoice
//            {
//                //url = "",
//                //contact = contact.UrlId(),
//                Status = Invoice.InvoiceStatus.Draft,
//                DatedOn = DateTime.Now,
//                PaymentTermsInDays = 25,
//                InvoiceItems = items
//            };
//        }

//        public override void CompareSingleItem(Invoice originalItem, Invoice newItem)
//        {
//            Assert.IsNotNull(newItem);
//            Assert.That(newItem.Url, Is.Null.Or.Empty);
//        }

//        public override bool CanDelete(Invoice item)
//        {
//            if (item == null) return false;

//            var newitem = ResourceClient.Get(item.Id());

//            if (newitem.InvoiceItems.Count == 0) return false;
//            foreach (var invoiceitem in newitem.InvoiceItems)
//            {
//                if (invoiceitem.Description.Contains("TEST")) return true;
//            }

//            return false;
//        }

//        //should add invoice timeline in here? 
//    }
//}
