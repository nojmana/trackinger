using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trackinger.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TrackingerContext(
                serviceProvider.GetRequiredService<DbContextOptions<TrackingerContext>>()))
            {
                if (context.Bug.Any() || context.User.Any())
                {
                    return; // database has already been initialized
                }

                context.User.AddRange(
                    new User
                    {
                        Id = 1,
                        Login = "abram11",
                        Name = "Abraham",
                        Surname = "Lincoln"
                    },
                    new User
                    {
                        Id = 2,
                        Login = "shakewill",
                        Name = "William",
                        Surname = "Shakespear"
                    },
                    new User
                    {
                        Id = 3,
                        Login = "deeper",
                        Name = "Johnny",
                        Surname = "Deep"
                    },
                    new User
                    {
                        Id = 4,
                        Login = "loveit",
                        Name = "Ada",
                        Surname = "Lovelace"
                    }
                );

          context.Bug.AddRange(
                    new Bug
                    {
                        Id = 1,
                        Description = "An error",
                        Priority = Priority.high,
                        Status = Status.open,
                        NotificationDate = new DateTime(),
                        CreatorId = 1,
                        AssigneeId = 2,
                    }
                );

                context.SaveChanges();
            }  

        }
    }
}
