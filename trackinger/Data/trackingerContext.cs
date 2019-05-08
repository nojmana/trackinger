using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using trackinger.Models;

namespace trackinger.Models
{
    public class trackingerContext : DbContext
    {
        public trackingerContext (DbContextOptions<trackingerContext> options)
            : base(options)
        {
        }

        public DbSet<trackinger.Models.User> User { get; set; }

        public DbSet<trackinger.Models.Bug> Bug { get; set; }
    }
}
