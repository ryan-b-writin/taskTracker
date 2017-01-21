using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BangazonTaskTracker.DAL;

namespace BangazonTaskTracker.Tests
{
    [TestClass]
    public class RepoTests
    {
        public TrackerRepo repo { get; set; }

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
    }
}
