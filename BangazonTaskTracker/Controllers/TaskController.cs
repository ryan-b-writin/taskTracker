using BangazonTaskTracker.DAL;
using BangazonTaskTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace BangazonTaskTracker.Controllers
{
    public class TaskController : ApiController
    {
        TrackerRepo repo = new TrackerRepo();
        public IHttpActionResult Post([FromBody]TaskInput new_task)
        {
            TrackerTask newTask = new TrackerTask { Name = new_task.Name, Description = new_task.Description};
            if (new_task.Status == TaskInput.TaskStatus.Complete)
            {
                newTask.Status = TrackerTask.TaskStatus.Complete;
                newTask.CompletedOn = new_task.CompletedOn;
            }
            else if (new_task.Status == TaskInput.TaskStatus.InProgress)
            {
                newTask.Status = TrackerTask.TaskStatus.InProgress;
            }
            else
            {
                newTask.Status = TrackerTask.TaskStatus.ToDo;
            }
            repo.Add(newTask);
            return Ok();
        }

        // GET: Task
        public IEnumerable<TrackerTask> Get([FromBody] int taskType)
        {
            return repo.GetTasksByStatus(taskType);
        }

        public IHttpActionResult Put([FromBody]TaskInput put)
        {
            return Ok();
        }
    }
}