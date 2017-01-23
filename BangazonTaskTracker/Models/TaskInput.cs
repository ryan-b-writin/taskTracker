using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangazonTaskTracker.Models
{
    public class TaskInput
    {
        public int TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public enum TaskStatus { ToDo, InProgress, Complete }
        public TaskStatus Status { get; set; }
        public DateTime CompletedOn { get; set; }
    }
}