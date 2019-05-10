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
    public class DeleteModel : PageModel
    {
        private readonly trackinger.Models.TrackingerContext _context;

        public DeleteModel(trackinger.Models.TrackingerContext context)
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
                .Include(b => b.Assignee)
                .Include(b => b.Creator).FirstOrDefaultAsync(m => m.Id == id);

            if (Bug == null)
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

            Bug = await _context.Bug.FindAsync(id);

            if (Bug != null)
            {
                _context.Bug.Remove(Bug);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
