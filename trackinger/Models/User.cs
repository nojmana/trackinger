using System;
using System.ComponentModel.DataAnnotations;

namespace trackinger.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Login { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Surname { get; set; }
    }
}