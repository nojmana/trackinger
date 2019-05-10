using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using trackinger.Models;

namespace trackinger.Models
{
    public class TrackingerContext : DbContext
    {
        public TrackingerContext (DbContextOptions<TrackingerContext> options)
            : base(options)
        {
        }

        public DbSet<trackinger.Models.User> User { get; set; }

        public DbSet<trackinger.Models.Bug> Bug { get; set; }
    }
}
