using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BangazonTaskTracker.DAL;
using Moq;
using System.Collections.Generic;
using BangazonTaskTracker.Models;
using System.Data.Entity;

namespace BangazonTaskTracker.Tests
{
    [TestClass]
    public class RepoTests
    {
        public TrackerRepo repo { get; set; }
        private Mock<TrackerContext> context = new Mock<TrackerContext>();
        private Mock<DbSet<TrackerTask>> tasks { get; set; } 
        private List<TrackerTask> task_list { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            tasks = new Mock<DbSet<TrackerTask>>();
            task_list = new List<TrackerTask> { new TrackerTask { Name = "test_task", Status = TrackerTask.TaskStatus.ToDo, } };
        }

        [TestMethod]
        public void CanCreateInstanceOfRepo()
        {
            repo = new TrackerRepo();
            Assert.IsNotNull(repo);
        }
        [TestMethod]
        public void RepositoryHasContextWhenInstantiated()
        {
            TrackerRepo repo = new TrackerRepo();
            Assert.IsNotNull(repo.Context);
        }
        [TestMethod]
        public void RepositoryCanAccessContext()
        {
            TrackerRepo repo = new TrackerRepo(context.Object);
            Assert.IsNotNull(repo.Context);  
            Assert.AreEqual(context.Object, repo.Context); 
        }
    }
}
