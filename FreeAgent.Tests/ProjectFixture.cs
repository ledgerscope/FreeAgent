using FreeAgent.Client;
using FreeAgent.Models;
using NUnit.Framework;

namespace FreeAgent.Tests
{
    [TestFixture]
    public class ProjectFixture : ResourceFixture<ProjectWrapper, ProjectsWrapper, Project>
    {
        public override ResourceClient<ProjectWrapper, ProjectsWrapper, Project> ResourceClient
        {
            get { return Client.Project; }
        }

        public override void CheckSingleItem(Project item)
        {
            Assert.That(item.Url.ToString(), Is.Null.Or.Empty);
            Assert.That(item.Name, Is.Null.Or.Empty);
            Assert.That(item.Contact, Is.Null.Or.Empty);
            Assert.That(item.Status, Is.Null.Or.Empty);
        }

        public override Project CreateSingleItemForInsert()
        {
            var contact = Client.Contact.All()[0];

            Assert.IsNotNull(contact);

            return new Project
            {
                //url = "",
                //Contact = contact.UrlId(),
                Name = "project TEST",
                Status = ProjectStatus.Active,
                BudgetUnits = ProjectBudgetUnits.Days,
                HoursPerDay = 7.5M,
                BillingPeriod = ProjectBillingPeriod.Day,
                NormalBillingRate = 450M,
                Currency = "GBP"
            };
        }

        public override void CompareSingleItem(Project originalItem, Project newItem)
        {
            Assert.IsNotNull(newItem);
            Assert.That(newItem.Url.ToString(), Is.Null.Or.Empty);
            Assert.AreEqual(newItem.Name, originalItem.Name);
            Assert.AreEqual(newItem.Status, originalItem.Status);
            Assert.AreEqual(newItem.BudgetUnits, originalItem.BudgetUnits);
            Assert.AreEqual(newItem.Currency, originalItem.Currency);
        }

        public override bool CanDelete(Project item)
        {
            return item.Name.Contains("TEST");
        }
    }
}
