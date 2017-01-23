using BangazonTaskTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BangazonTaskTracker.DAL
{
    public class TrackerRepo
    {
        public TrackerContext Context { get; set; }
        public TrackerRepo(TrackerContext context)
        {
            Context = context;
        }
        public TrackerRepo()
        {
            this.Context = new TrackerContext();
        }

        public List<TrackerTask> GetAll()
        {
            return Context.Tasks.ToList();
        }

        public void Add(TrackerTask Task)
        {
            Context.Tasks.Add(Task);
            Context.SaveChanges();
        }

        public void editTask(TaskInput editInput)
        {
            TrackerTask taskToEdit = Context.Tasks.FirstOrDefault(t => t.TaskID == editInput.TaskID);

            taskToEdit.Name = editInput.Name;
            taskToEdit.Description = editInput.Description;
            if (editInput.Status == TaskInput.TaskStatus.ToDo)
            {
                taskToEdit.Status = TrackerTask.TaskStatus.ToDo;
            }
            else if (editInput.Status == TaskInput.TaskStatus.InProgress)
            {
                taskToEdit.Status = TrackerTask.TaskStatus.InProgress;
            }
            else if (editInput.Status == TaskInput.TaskStatus.Complete)
            {
                taskToEdit.Status = TrackerTask.TaskStatus.Complete;
                taskToEdit.CompletedOn = DateTime.Now;
            }

            Context.SaveChanges();
        }

        public List<TrackerTask> GetTasksByStatus(int v)
        {
            throw new NotImplementedException();
        }
    }
}