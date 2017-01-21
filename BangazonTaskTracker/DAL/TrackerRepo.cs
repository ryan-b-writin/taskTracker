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
        public TrackerRepo()
        {
            this.Context = new TrackerContext();
        }
    }
}