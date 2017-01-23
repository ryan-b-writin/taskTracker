using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BangazonTaskTracker.DAL;
using Moq;
using System.Collections.Generic;
using BangazonTaskTracker.Models;
using System.Data.Entity;
using System.Linq;

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
            task_list = new List<TrackerTask> { new TrackerTask { Name = "test_task", Status = TrackerTask.TaskStatus.ToDo } };
        }

        public void SetUpMocksAsQueryable()
        {
            var task_queryable = task_list.AsQueryable();

            tasks.As<IQueryable<TrackerTask>>().Setup(x => x.Provider).Returns(task_queryable.Provider);
            tasks.As<IQueryable<TrackerTask>>().Setup(x => x.Expression).Returns(task_queryable.Expression);
            tasks.As<IQueryable<TrackerTask>>().Setup(x => x.ElementType).Returns(task_queryable.ElementType);
            tasks.As<IQueryable<TrackerTask>>().Setup(x => x.GetEnumerator()).Returns(() => task_queryable.GetEnumerator());

            tasks.Setup(t => t.Add(It.IsAny<TrackerTask>())).Callback((TrackerTask task) => task_list.Add(task));

            context.Setup(x => x.Tasks).Returns(tasks.Object);
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
        [TestMethod]
        public void CanGetAllTasks()
        {
            SetUpMocksAsQueryable();
            var repo = new TrackerRepo(context.Object);

            var actualTasks = repo.GetAll();
            
            Assert.AreEqual(actualTasks.Count, 1); 
        }
        [TestMethod]
        public void CanAddTask()
        {
            SetUpMocksAsQueryable();
            var repo = new TrackerRepo(context.Object);
            TrackerTask testTask = new TrackerTask { Name = "a new task", Status = TrackerTask.TaskStatus.ToDo };

            repo.Add(testTask);

            tasks.Verify(x => x.Add(testTask), Times.Once); 
            Assert.IsTrue(task_list.Contains(testTask));
        }
        [TestMethod]
        public void CanEditTask()
        {
            SetUpMocksAsQueryable();
            var repo = new TrackerRepo(context.Object);
            TrackerTask taskToEdit = task_list.FirstOrDefault(u => u.Name == "test_task");
            int edited_task_id = taskToEdit.TaskID;
            string expected_name = "edited name";
            string expected_description = "edited description";
            TaskInput editInput = new TaskInput { TaskID = edited_task_id, Name = expected_name, Description = expected_description, Status = TaskInput.TaskStatus.Complete };
            TrackerTask edited_task = task_list.FirstOrDefault(t => t.TaskID == edited_task_id);
            Assert.AreNotEqual(edited_task.CompletedOn.Year, DateTime.Now.Year);

            repo.editTask(editInput);

            string actual_name = edited_task.Name;
            string actual_description = edited_task.Description;

            Assert.AreEqual(expected_name, actual_name);
            Assert.AreEqual(expected_description, actual_description);
            Assert.IsTrue(edited_task.Status == TrackerTask.TaskStatus.Complete);
            Assert.AreEqual(edited_task.CompletedOn.Year, DateTime.Now.Year);  
        }
        [TestMethod]
        public void ReturnListByStatus()
        {
            SetUpMocksAsQueryable();
            var repo = new TrackerRepo(context.Object);

            List<TrackerTask> todo_tasks = repo.GetTasksByStatus(0);
            List<TrackerTask> in_progress_tasks = repo.GetTasksByStatus(1);

            int expected_todo_length = 1;
            int actual_todo_length = todo_tasks.Count;
            int expected_progress_length = 0;
            int actual_progress_length = in_progress_tasks.Count();

            Assert.AreEqual(expected_todo_length, actual_todo_length);
            Assert.AreEqual(expected_progress_length, actual_progress_length);
        }
    }
}
