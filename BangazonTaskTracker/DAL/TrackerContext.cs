using BangazonTaskTracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BangazonTaskTracker.DAL
{
    public class TrackerContext : ApplicationDbContext
    {
        public virtual DbSet<TrackerTask> Tasks { get; set; }
    }
}