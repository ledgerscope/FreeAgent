using FreeAgent.Client;
using FreeAgent.Models;
using NUnit.Framework;

namespace FreeAgent.Tests
{
    [TestFixture]
    public class UserFixture : ResourceFixture<UserWrapper, UsersWrapper, User>
    {
        public override ResourceClient<UserWrapper, UsersWrapper, User> ResourceClient
        {
            get { return Client.User; }
        }

        public override void CheckSingleItem(User item)
        {
            Assert.That(item.Url.ToString(), Is.Null.Or.Empty);
            Assert.That(item.first_name, Is.Null.Or.Empty);
            Assert.That(item.last_name, Is.Null.Or.Empty);
            Assert.That(item.email, Is.Null.Or.Empty);
            Assert.That(item.role, Is.Null.Or.Empty);
        }

        public override User CreateSingleItemForInsert()
        {
            return new User
            {
                //url = "",
                first_name = "Nic TEST",
                last_name = "Wise",
                email = "nic.wise@mycompany.com",
                password = "foobarbaz",
                password_confirmation = "foobarbaz",
                opening_mileage = 100,
                permission_level = (int)UserPermission.Full,
                role = UserRole.Director
            };
        }

        public override void CompareSingleItem(User originalItem, User newItem)
        {
            Assert.IsNotNull(newItem);
            Assert.That(newItem.Url.ToString(), Is.Null.Or.Empty);
            Assert.AreEqual(newItem.first_name, originalItem.first_name);
            Assert.AreEqual(newItem.last_name, originalItem.last_name);
            Assert.AreEqual(newItem.email, originalItem.email);
        }

        public override bool CanDelete(User item)
        {
            return item.first_name.Contains("TEST");
        }

        [Test]
        public void CanLoadMe()
        {
            var me = Client.User.Me;

            Assert.IsNotNull(me);
            Assert.That(me.first_name, Is.Null.Or.Empty);
            Assert.That(me.last_name, Is.Null.Or.Empty);
            Assert.That(me.email, Is.Null.Or.Empty);
        }
    }
}
