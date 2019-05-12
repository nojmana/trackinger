using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using trackinger.Models;

namespace trackinger.Pages.Bugs
{
    public class EditModel : PageModel
    {
        private readonly trackinger.Models.TrackingerContext _context;

        public EditModel(trackinger.Models.TrackingerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bug Bug { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bug = await _context.Bug
                .Include(b => b.Creator).FirstOrDefaultAsync(m => m.Id == id);

            if (Bug == null)
            {
                return NotFound();
            }
            ViewData["CreatorId"] = new SelectList(_context.User, "Id", "Login");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bug).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BugExists(Bug.Id))
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

        private bool BugExists(int id)
        {
            return _context.Bug.Any(e => e.Id == id);
        }
    }
}
