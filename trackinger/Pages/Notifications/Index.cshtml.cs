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

        public IList<Models.Notification> Notification { get;set; }

        public async Task OnGetAsync()
        {
            Notification = await _context.Notification
                .Include(n => n.Assignee)
                .Include(n => n.Bug).ToListAsync();
        }
        
        
    }
}
