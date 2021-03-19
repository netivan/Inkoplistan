using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inkoplistan.Data;
using Inkoplistan.Models;

namespace Inkoplistan.Pages.InfoProduct
{
    public class EditModel : PageModel
    {
        private readonly Inkoplistan.Data.InkoplistanContext _context;

        public EditModel(Inkoplistan.Data.InkoplistanContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Matvara).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatvaraExists(Matvara.ID))
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

        private bool MatvaraExists(int id)
        {
            return _context.Matvara.Any(e => e.ID == id);
        }
    }
}
