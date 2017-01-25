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
            return Ok();
        }

        // GET: Task
        public IEnumerable<TrackerTask> Get()
        {
            return null;
        }

        public IHttpActionResult Put([FromBody]TaskInput put)
        {
            return Ok();
        }
    }
}