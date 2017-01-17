using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BangazonTaskTracker.Models
{
    public class TrackerTask
    {
        [Key]
        public int TaskID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public enum TaskStatus { ToDo, InProgress, Complete }
        [Required]
        public TaskStatus Status {get; set;}
        public DateTime CompletedOn { get; set; }
    }
}