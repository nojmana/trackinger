using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace trackinger.Models
{
    public class Notification
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime NotificationDate { get; set; }
        public String Description { get; set; }
        public Status Status { get; set; }
        public int BugId { get; set; }
        public Bug Bug { get; set; }
        public int? AssigneeId { get; set; }
        public User Assignee { get; set; }

    }
}
