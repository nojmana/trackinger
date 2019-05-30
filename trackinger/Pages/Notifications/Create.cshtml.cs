using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using trackinger.Models;

namespace trackinger.Pages.Notification
{
    public class CreateModel : PageModel
    {
        private readonly trackinger.Models.TrackingerContext _context;

        public CreateModel(trackinger.Models.TrackingerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AssigneeId"] = new SelectList(_context.User, "Id", "Login");
        ViewData["BugId"] = new SelectList(_context.Bug, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public Models.Notification Notification { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            String eeelele = Notification.ToString();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Notification.Add(Notification);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}