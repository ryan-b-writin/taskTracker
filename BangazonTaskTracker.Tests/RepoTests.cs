using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BangazonTaskTracker.DAL;
using Moq;

namespace BangazonTaskTracker.Tests
{
    [TestClass]
    public class RepoTests
    {
        public TrackerRepo repo { get; set; }
        private Mock<TrackerContext> context = new Mock<TrackerContext>();

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
