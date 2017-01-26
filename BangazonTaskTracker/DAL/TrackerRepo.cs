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
                //check if task is already marked completed to avoid resetting CompletedOn date
                if (taskToEdit.Status != TrackerTask.TaskStatus.Complete)
                {
                    taskToEdit.Status = TrackerTask.TaskStatus.Complete;
                    taskToEdit.CompletedOn = DateTime.Now;
                }
            }

            Context.SaveChanges();
        }

        //0 returns ToDo tasks, 1 returns InProgress tasks, 2 returns completed tasks
        public List<TrackerTask> GetTasksByStatus(int v)
        {
            if (v == 0)
            {
                return Context.Tasks.Where(t => t.Status == TrackerTask.TaskStatus.ToDo).ToList();
            }
            else if ( v == 1)
            {
                return Context.Tasks.Where(t => t.Status == TrackerTask.TaskStatus.InProgress).ToList();
            }
            else if (v == 2 )
            {
                return Context.Tasks.Where(t => t.Status == TrackerTask.TaskStatus.Complete).ToList();
            }
            else
            {
                return GetAll();
            }
        }
    }
}