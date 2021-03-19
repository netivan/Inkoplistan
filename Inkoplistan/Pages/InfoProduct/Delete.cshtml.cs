using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inkoplistan.Data;
using Inkoplistan.Models;

namespace Inkoplistan.Pages.InfoProduct
{
    public class DeleteModel : PageModel
    {
        private readonly Inkoplistan.Data.InkoplistanContext _context;

        public DeleteModel(Inkoplistan.Data.InkoplistanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Matvara Matvara { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Matvara = await _context.Matvara.FirstOrDefaultAsync(m => m.ID == id);

            if (Matvara == null)
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

            Matvara = await _context.Matvara.FindAsync(id);

            if (Matvara != null)
            {
                _context.Matvara.Remove(Matvara);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
