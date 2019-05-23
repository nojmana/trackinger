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

        [Display(Name = "Notification date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime NotificationDate { get; set; }

        [Required] public String Description { get; set; }
        [Required] public Status Status { get; set; }
        [Required] [Display(Name = "Bug")] public int BugId { get; set; }
        [Required] public Bug Bug { get; set; }
        [Display(Name = "Assignee")] public int? AssigneeId { get; set; }
        public User Assignee { get; set; }
    }
}