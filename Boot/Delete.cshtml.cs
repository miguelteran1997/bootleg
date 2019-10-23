using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OffPractice.Data;

namespace OffPractice.Pages.Boot
{
    public class DeleteModel : PageModel
    {
        private readonly OffPractice.Data.ApplicationDbContext _context;

        public DeleteModel(OffPractice.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bootleg Bootleg { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bootleg = await _context.Bootleg.FirstOrDefaultAsync(m => m.BID == id);

            if (Bootleg == null)
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

            Bootleg = await _context.Bootleg.FindAsync(id);

            if (Bootleg != null)
            {
                _context.Bootleg.Remove(Bootleg);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
