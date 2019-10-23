using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OffPractice.Data;

namespace OffPractice.Pages.Boot
{
    public class CreateModel : PageModel
    {
        private readonly OffPractice.Data.ApplicationDbContext _context;

        public CreateModel(OffPractice.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Bootleg Bootleg { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bootleg.Add(Bootleg);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}