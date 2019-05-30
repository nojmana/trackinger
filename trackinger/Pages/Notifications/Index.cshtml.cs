using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using trackinger.Models;

namespace trackinger.Pages.Notification
{
    public class IndexModel : PageModel
    {
        private readonly trackinger.Models.TrackingerContext _context;

        public IndexModel(trackinger.Models.TrackingerContext context)
        {
            _context = context;
        }

        public string NotificationDateSort { get; set; }
        public string DescriptionSort { get; set; }
        public string StatusSort { get; set; }
        public string BugSort { get; set; }
        public string AssigneeSort { get; set; }

        public IList<Models.Notification> Notification { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NotificationDateSort = String.IsNullOrEmpty(sortOrder) ? "" : "date_asc";
            NotificationDateSort = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            DescriptionSort = sortOrder == "description_asc" ? "description_desc" : "description_asc";
            StatusSort = sortOrder == "status_asc"  ? "status_desc" : "status_asc";
            BugSort = sortOrder == "bug_asc"  ? "bug_desc" : "bug_asc";
            AssigneeSort = sortOrder == "assignee_asc" ? "assignee_desc" : "assignee_asc";

            var notificationIQ = from n in _context.Notification
                select n;

            switch (sortOrder)
            {
                case "date_asc":
                    notificationIQ = notificationIQ.OrderBy(n => n.NotificationDate);
                    break;
                case "date_desc":
                    notificationIQ = notificationIQ.OrderByDescending(n => n.NotificationDate);
                    break;
                case "description_asc":
                    notificationIQ = notificationIQ.OrderBy(n => n.Description);
                    break;
                case "description_desc":
                    notificationIQ = notificationIQ.OrderByDescending(n => n.Description);
                    break;
                case "status_asc":
                    notificationIQ = notificationIQ.OrderBy(n => n.Status);
                    break;
                case "status_desc":
                    notificationIQ = notificationIQ.OrderByDescending(n => n.Status);
                    break;
                case "bug_asc":
                    notificationIQ = notificationIQ.OrderBy(n => n.Bug.Title);
                    break;
                case "bug_desc":
                    notificationIQ = notificationIQ.OrderByDescending(n => n.Bug.Title);
                    break;
                case "assignee_asc":
                    notificationIQ = notificationIQ.OrderBy(n => n.Assignee.Login);
                    break;
                case "assignee_desc":
                    notificationIQ = notificationIQ.OrderByDescending(n => n.Assignee.Login);
                    break;
                default:
                    notificationIQ = notificationIQ.OrderBy(n => n.NotificationDate);
                    break;

            }

            Notification = await notificationIQ
                .Include(n => n.Assignee)
                .Include(n => n.Bug)
                .AsNoTracking().ToListAsync();
        }
        
        
    }
}
