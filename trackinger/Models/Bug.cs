using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace trackinger.Models
{
    public enum Status
    {
        open,
        in_progress,
        done
    }

    public enum Priority
    {
        low,
        medium,
        high
    }

    public class Bug
    {
        public int Id { get; set; }

        [Display(Name = "Creation date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime CreationDate { get; set; }

        [Required] public String Title { get; set; }
        [Required] public String Description { get; set; }
        public Priority Priority { get; set; }
        [Required]
        [Display(Name = "Creator")] public int? CreatorId { get; set; }
        public User Creator { get; set; }
        public IList<Notification> Notification { get; set; }
    }
}