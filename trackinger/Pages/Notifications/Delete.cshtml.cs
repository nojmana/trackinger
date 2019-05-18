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
    public class DeleteModel : PageModel
    {
        private readonly trackinger.Models.TrackingerContext _context;

        public DeleteModel(trackinger.Models.TrackingerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notification = await _context.Notification.FindAsync(id);

            if (Notification != null)
            {
                _context.Notification.Remove(Notification);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
