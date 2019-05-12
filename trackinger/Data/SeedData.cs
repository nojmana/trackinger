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
        public static void Initialize(TrackingerContext context)
        {
            if (context.Bug.Any() && context.User.Any())
            {
                return; // database has already been initialized
            }

            context.User.AddRange(
                new User
                {
                    Login = "abram11",
                    Name = "Abraham",
                    Surname = "Lincoln"
                },
                new User
                {
                    Login = "shakewill",
                    Name = "William",
                    Surname = "Shakespear"
                },
                new User
                {
                    Login = "deeper",
                    Name = "Johnny", 
                    Surname = "Deep"
                },
                new User
                {
                    Login = "loveit",
                    Name = "Ada",
                    Surname = "Lovelace"
                }
            );

            context.SaveChanges();


            context.Bug.AddRange(
                new Bug
                {
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed rutrum, purus eu aliquam blandit, lectus dolor tincidunt urna, vitae",
                    Priority = Priority.high,
                    Status = Status.open,
                    NotificationDate = new DateTime(2019, 5, 12, 12, 30, 52),
                    CreatorId = 1
                },
                new Bug
                {
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam venenatis lorem orci, sed placerat mi sodales vitae. Nam at tortor.",
                    Priority = Priority.medium,
                    Status = Status.in_progress,
                    NotificationDate = new DateTime(2019, 4, 1, 13, 30, 52),
                    CreatorId = 2,
                    AssigneeId = 1
                },
                new Bug
                {
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed rutrum, purus eu aliquam blandit, lectus dolor sodales vitae. Nam at tortor.",
                    Priority = Priority.medium,
                    Status = Status.in_progress,
                    NotificationDate = new DateTime(2019, 5, 2, 7, 31, 52),
                }
            );

            context.SaveChanges();
        }
    }
}