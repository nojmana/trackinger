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
    public class DetailsModel : PageModel
    {
        private readonly trackinger.Models.TrackingerContext _context;

        public DetailsModel(trackinger.Models.TrackingerContext context)
        {
            _context = context;
        }

        public Models.Notification Notification { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notification = await _context.Notification
                .Include(n => n.Assignee)
                .Include(n => n.Bug).FirstOrDefaultAsync(m => m.Id == id);

            if (Notification == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
