using System;
using System.ComponentModel.DataAnnotations;

namespace trackinger.Models
{

    public enum Status
    {
        open, in_progress, done
    }

    public enum Priority
    {
        low, medium, high
    }
    public class Bug
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime NotificationDate { get; set; }
        public String Description { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public int? CreatorId { get; set; }
        public int? AssigneeId { get; set; }
        public User Creator { get; set; }
        public User Assignee { get; set; }



    }
}