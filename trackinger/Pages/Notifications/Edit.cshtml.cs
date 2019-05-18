using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trackinger.Models;

namespace trackinger.Pages.Notification
{
    public class EditModel : PageModel
    {
        private readonly trackinger.Models.TrackingerContext _context;

        public EditModel(trackinger.Models.TrackingerContext context)
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
           ViewData["AssigneeId"] = new SelectList(_context.User, "Id", "Login");
           ViewData["BugId"] = new SelectList(_context.Bug, "Id", "Title");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Notification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationExists(Notification.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NotificationExists(int id)
        {
            return _context.Notification.Any(e => e.Id == id);
        }
    }
}
