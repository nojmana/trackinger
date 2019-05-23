using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using trackinger.Models;

namespace trackinger.Pages.Bugs
{
    public class IndexModel : PageModel
    {
        private readonly trackinger.Models.TrackingerContext _context;

        public IndexModel(trackinger.Models.TrackingerContext context)
        {
            _context = context;
        }
        
        public string CreationDateSort { get; set; }
        public string TitleSort { get; set; }
        public string DescriptionSort { get; set; }
        public string CreatorSort { get; set; }
        public string PrioritySort { get; set; }

        public IList<Bug> Bug { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            CreationDateSort = String.IsNullOrEmpty(sortOrder) ? "" : "date_asc";
            CreationDateSort = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            TitleSort = sortOrder == "title_asc" ? "title_desc" : "title_asc";
            DescriptionSort = sortOrder == "description_asc"  ? "description_desc" : "description_asc";
            PrioritySort = sortOrder == "priority_asc"  ? "priority_desc" : "priority_asc";
            CreatorSort = sortOrder == "creator_asc" ? "creator_desc" : "creator_asc";
            
            var bugIQ = from b in _context.Bug
                select b;

            switch (sortOrder)
            {
                case "date_asc":
                    bugIQ = bugIQ.OrderBy(b => b.CreationDate);
                    break;
                case "date_desc":
                    bugIQ = bugIQ.OrderByDescending(b => b.CreationDate);
                    break;
                case "title_asc":
                    bugIQ = bugIQ.OrderBy(b => b.Title);
                    break;
                case "title_desc":
                    bugIQ = bugIQ.OrderByDescending(b => b.Title);
                    break;
                case "description_asc":
                    bugIQ = bugIQ.OrderBy(b => b.Description);
                    break;
                case "description_desc":
                    bugIQ = bugIQ.OrderByDescending(b => b.Description);
                    break;
                case "priority_asc":
                    bugIQ = bugIQ.OrderBy(b => b.Priority);
                    break;
                case "priority_desc":
                    bugIQ = bugIQ.OrderByDescending(b => b.Priority);
                    break;
                case "creator_asc":
                    bugIQ = bugIQ.OrderBy(b => b.Creator.Login);
                    break;
                case "creator_desc":
                    bugIQ = bugIQ.OrderByDescending(b => b.Creator.Login);
                    break;
                default:
                    bugIQ = bugIQ.OrderBy(b => b.CreationDate);
                    break;
            }

            Bug = await bugIQ.Include(b => b.Creator).AsNoTracking().ToListAsync();
        }

    }
}
