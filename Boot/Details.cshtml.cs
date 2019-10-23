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
    public class DetailsModel : PageModel
    {
        private readonly OffPractice.Data.ApplicationDbContext _context;

        public DetailsModel(OffPractice.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
