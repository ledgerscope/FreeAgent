//using FreeAgent.Client;
//using FreeAgent.Models;
//using NUnit.Framework;

//namespace FreeAgent.Tests
//{
//    [TestFixture]
//    public class UserFixture : ResourceFixture<UserWrapper, UsersWrapper, User>
//    {
//        public override ResourceClient<UserWrapper, UsersWrapper, User> ResourceClient
//        {
//            get { return Client.User; }
//        }

//        public override void CheckSingleItem(User item)
//        {
//            Assert.That(item.Url.ToString(), Is.Null.Or.Empty);
//            Assert.That(item.FirstName, Is.Null.Or.Empty);
//            Assert.That(item.LastName, Is.Null.Or.Empty);
//            Assert.That(item.Email, Is.Null.Or.Empty);
//            Assert.That(item.Role, Is.Null.Or.Empty);
//        }

//        public override User CreateSingleItemForInsert()
//        {
//            return new User
//            {
//                //url = "",
//                FirstName = "Nic TEST",
//                LastName = "Wise",
//                Email = "nic.wise@mycompany.com",
//                //password = "foobarbaz",
//                //password_confirmation = "foobarbaz",
//                OpeningMileage = 100,
//                PermissionLevel = (int)PermissionLevel.Full,
//                Role = User.UserRole.Director
//            };
//        }

//        public override void CompareSingleItem(User originalItem, User newItem)
//        {
//            Assert.IsNotNull(newItem);
//            Assert.That(newItem.Url.ToString(), Is.Null.Or.Empty);
//            Assert.AreEqual(newItem.FirstName, originalItem.FirstName);
//            Assert.AreEqual(newItem.LastName, originalItem.LastName);
//            Assert.AreEqual(newItem.Email, originalItem.Email);
//        }

//        public override bool CanDelete(User item)
//        {
//            return item.FirstName.Contains("TEST");
//        }

//        [Test]
//        public void CanLoadMe()
//        {
//            var me = Client.User.Me;

//            Assert.IsNotNull(me);
//            Assert.That(me.FirstName, Is.Null.Or.Empty);
//            Assert.That(me.LastName, Is.Null.Or.Empty);
//            Assert.That(me.Email, Is.Null.Or.Empty);
//        }
//    }
//}
