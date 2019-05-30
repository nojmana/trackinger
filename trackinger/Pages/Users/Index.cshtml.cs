using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using trackinger.Models;

namespace trackinger.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly trackinger.Models.TrackingerContext _context;

        public IndexModel(trackinger.Models.TrackingerContext context)
        {
            _context = context;
        }
        
        public string LoginSort { get; set; }
        public string NameSort { get; set; }
        public string SurnameSort { get; set; }


        public IList<User> User { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            LoginSort = String.IsNullOrEmpty(sortOrder) ? "" : "login_asc";
            LoginSort = sortOrder == "login_asc" ? "login_desc" : "login_asc";
            NameSort = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            SurnameSort = sortOrder == "surname_asc"  ? "surname_desc" : "surname_asc";

            var userIQ = from u in _context.User
                select u;

            switch (sortOrder)
            {
                case "login_asc":
                    userIQ = userIQ.OrderBy(u => u.Login);
                    break;
                case "login_desc":
                    userIQ = userIQ.OrderByDescending(u => u.Login);
                    break;
                case "name_asc":
                    userIQ = userIQ.OrderBy(u => u.Name);
                    break;
                case "name_desc":
                    userIQ = userIQ.OrderByDescending(u => u.Name);
                    break;
                case "surname_asc":
                    userIQ = userIQ.OrderBy(u => u.Surname);
                    break;
                case "surname_desc":
                    userIQ = userIQ.OrderByDescending(u => u.Surname);
                    break;
                default:
                    userIQ = userIQ.OrderBy(u => u.Login);
                    break;
            }

            User = await userIQ.AsNoTracking().ToListAsync();
        }
    }
}
