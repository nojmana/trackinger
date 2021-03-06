﻿using System;
using System.Linq;

namespace trackinger.Models
{
    public static class SeedData
    {
        public static void Initialize(TrackingerContext context)
        {
            if (context.User.Any() && context.Bug.Any() && context.Notification.Any())
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
                    Title = "Shopping cart display",
                    Description =
                        "When opening a shopping cart display, webpage crushes and there is a 500 http error displayed.",
                    Priority = Priority.medium,
                    CreationDate = new DateTime(2019, 5, 12, 12, 30, 52),
                    CreatorId = 1
                },
                new Bug
                {
                    Title = "Logging with invalid credentials",
                    Description =
                        "When user enters wrong password, he is authorized anyway.",
                    Priority = Priority.high,
                    CreationDate = new DateTime(2019, 4, 1, 13, 30, 52),
                    CreatorId = 2
                }
            );
            context.SaveChanges();

            context.Notification.AddRange(
                new Notification
                {
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed rutrum, purus eu aliquam blandit, lectus dolor tincidunt urna, vitae",
                    BugId = 1,
                    AssigneeId = 1,
                    Status = Status.open,
                    NotificationDate = new DateTime(2019, 5, 12, 12, 30, 52)
                },
                new Notification
                {
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed rutrum, purus eu aliquam blandit, lectus dolor tincidunt urna, vitae",
                    BugId = 2,
                    AssigneeId = 2,
                    Status = Status.open,
                    NotificationDate = new DateTime(2019, 4, 1, 13, 30, 52)
                },
                new Notification
                {
                    Description =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed rutrum, purus eu aliquam blandit, lectus dolor tincidunt urna, vitae",
                    BugId = 2,
                    AssigneeId = 3,
                    Status = Status.in_progress,
                    NotificationDate = new DateTime(2019, 4, 3, 13, 30, 52)
                }
            );
            context.SaveChanges();
        }
    }
}