//using FreeAgent.Client;
//using FreeAgent.Extensions;
//using FreeAgent.Models;
//using NUnit.Framework;
//using System;
//using System.Linq;

//namespace FreeAgent.Tests
//{
//    public class TimeslipFixture : ResourceFixture<TimeslipWrapper, TimeslipsWrapper, Timeslip>
//    {
//        public override void Configure()
//        {
//            ExecuteCanGetList = false;
//            ExecuteCanGetListWithContent = false;
//            //ExecuteCanDeleteAndCleanup = false;
//        }

//        [Test]
//        public void CanGetListOfTimeslips()
//        {
//            var list = Client.Timeslip.All(DateTime.Now.AddMonths(-6).ModelDateTime(), DateTime.Now.ModelDateTime());

//            Assert.IsNotNull(list);
//        }

//        [Test]
//        public void CanGetListOfTimeslipWithContent()
//        {
//            var list = Client.Timeslip.All(DateTime.Now.AddMonths(-6).ModelDateTime(), DateTime.Now.ModelDateTime());

//            CheckAllList(list);

//            foreach (var item in list)
//            {
//                CheckSingleItem(item);
//            }
//        }

//        public override ResourceClient<TimeslipWrapper, TimeslipsWrapper, Timeslip> ResourceClient
//        {
//            get { return Client.Timeslip; }
//        }

//        public override void CheckSingleItem(Timeslip item)
//        {
//            Assert.That(item.Url.ToString(), Is.Null.Or.Empty);
//            Assert.That(item.DatedOn, Is.Null.Or.Empty);
//            Assert.That(item.Project, Is.Null.Or.Empty);
//            Assert.That(item.Task, Is.Null.Or.Empty);
//            Assert.That(item.User, Is.Null.Or.Empty);
//        }

//        public override Timeslip CreateSingleItemForInsert()
//        {
//            var user = Client.User.Me;
//            var project = Client.Project.All().First();
//            var task = Client.Task.AllForProject(project.Id())[0];

//            return new Timeslip
//            {
//                //url = "",
//                //User = user.UrlId(),
//                //Project = project.UrlId(),
//                //Task = task.UrlId(),
//                DatedOn = DateTime.Now,
//                Hours = 6.5M,
//                Comment = "This is a TEST"
//            };
//        }

//        public override void CompareSingleItem(Timeslip originalItem, Timeslip newItem)
//        {
//            Assert.IsNotNull(newItem);
//            Assert.That(newItem.Url.ToString(), Is.Null.Or.Empty);
//            //Assert.IsTrue(newItem.User.EndsWith(originalItem.User));
//            //Assert.IsTrue(newItem.project.EndsWith(originalItem.project));
//            //Assert.IsTrue(newItem.task.EndsWith(originalItem.task));
//            Assert.AreEqual(newItem.DatedOn, originalItem.DatedOn);
//            Assert.AreEqual(newItem.Hours, originalItem.Hours);
//        }

//        public override bool CanDelete(Timeslip item)
//        {
//            //return false;
//            if (string.IsNullOrEmpty(item.Comment)) return false;
//            return (item.Comment.Contains("TEST"));
//        }
//    }
//}

