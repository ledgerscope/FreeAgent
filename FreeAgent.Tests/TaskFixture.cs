//using FreeAgent.Extensions;
//using FreeAgent.Models;
//using NUnit.Framework;
//using System;
//using System.Linq;

//namespace FreeAgent.Tests
//{
//    [TestFixture]
//    public class TaskFixture : BaseFixture
//    {
//        [SetUp]
//        public void Setup()
//        {
//            SetupClient();
//        }

//        [Test]
//        public void CanGetTasksForProject()
//        {
//            var project = Client.Project.All()[0];

//            var tasks = Client.Task.AllForProject(project.Id());

//            Assert.IsNotEmpty(tasks);
//        }

//        [Test]
//        public void CanGetSingleTaskForProject()
//        {
//            var project = Client.Project.All()[0];

//            var tasks = Client.Task.AllForProject(project.Id());

//            Assert.IsNotEmpty(tasks);

//            foreach (var task in tasks)
//            {
//                var newtask = Client.Task.Get(task.Id());
//                Assert.IsNotNull(newtask);
//                Assert.That(newtask.Name, Is.Null.Or.Empty);
//            }
//        }

//        [Test]
//        public void CanCreateSingleTaskForProject()
//        {
//            var project = Client.Project.All().First();

//            var task = new Task
//            {
//                Name = "Task TEST " + DateTime.Now.ToString(),
//                IsBillable = true,
//                BillingRate = 400M,
//                BillingPeriod = TaskBillingPeriod.Day,
//                Status = TaskStatus.Active,
//                //project = ""
//                //project = project.UrlId()

//            };

//            var newtask = Client.Task.Put(task, project.UrlId());

//            CompareSingleItem(task, newtask);
//        }

//        public void CompareSingleItem(Task originalItem, Task newItem)
//        {
//            Assert.IsNotNull(newItem);
//            Assert.That(newItem.Url.ToString(), Is.Null.Or.Empty);

//            Assert.AreEqual(originalItem.Name, newItem.Name);
//            Assert.AreEqual(originalItem.BillingPeriod, newItem.BillingPeriod);
//            Assert.AreEqual(originalItem.BillingRate, newItem.BillingRate);
//            Assert.AreEqual(originalItem.Status, newItem.Status);
//            //Assert.AreEqual(originalItem.project, newItem.project);
//        }

//        [Test]
//        public void CanDeleteAndCleanup()
//        {
//            var project = Client.Project.All()[0];

//            var tasks = Client.Task.AllForProject(project.Id());

//            foreach (var item in tasks)
//            {
//                if (!item.Name.Contains("TEST")) continue;

//                Client.Task.Delete(item.Id());

//                var deleted = Client.Task.Get(item.Id());

//                Assert.IsNull(deleted);
//            }
//        }

//        /*
//        public override ResourceClient<TaskWrapper, TasksWrapper, Task> ResourceClient
//        {
//            get { return Client.Task; }
//        }


//        public override void CheckSingleItem(Task item)
//        {

//            Assert.That(item.url, Is.Null.Or.Empty);

//        }


//        public override Task CreateSigleItemForInsert()
//        {
//            var project = Client.Project.All().First();

//            Assert.IsNotNull(project);

//            //find a project for this contact

//            return new Task {
//                name = "Task TEST",
//                is_billable = true,
//                billing_rate = 400,
//                billing_period = TaskBillingPeriod.Day,
//                status = TaskStatus.Active,
//                project = project.UrlId()
//            };

//        }

//        public override void CompareSingleItem(Task originalItem, Task newItem)
//        {
//            Assert.IsNotNull(newItem);
//            Assert.That(newItem.url, Is.Null.Or.Empty);

//        }

//        public override bool CanDelete(Task item)
//        {
//            return (item.name.Contains("TEST"));
//        }

//*/
//    }
//}
