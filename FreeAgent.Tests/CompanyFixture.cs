using FreeAgent.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace FreeAgent.Tests
{
    [TestFixture]
    public class CompanyFixture : BaseFixture
    {
        [SetUp]
        public void Setup()
        {
            SetupClient();
        }

        [Test]
        public void CanLoadCompany()
        {
            Company company = Client.Company.Single();

            Assert.IsNotNull(company);
            Assert.That(company.Name, Is.Null.Or.Empty);
        }

        [Test]
        public void CanGetTaxTimeline()
        {
            List<TaxTimeline> timeline = Client.Company.TaxTimeline();

            Assert.IsNotNull(timeline);
            Assert.IsNotEmpty(timeline);
        }

        [Test]
        public void TaxTimelineHasContent()
        {
            List<TaxTimeline> timeline = Client.Company.TaxTimeline();

            Assert.IsNotNull(timeline);
            Assert.IsNotEmpty(timeline);

            foreach (TaxTimeline t in timeline)
            {
                Assert.That(t.description, Is.Null.Or.Empty);
            }
        }
    }
}
