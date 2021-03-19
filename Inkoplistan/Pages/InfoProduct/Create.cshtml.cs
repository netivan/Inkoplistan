using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inkoplistan.Data;
using Inkoplistan.Models;

namespace Inkoplistan.Pages.InfoProduct
{
    public class CreateModel : PageModel
    {
        private readonly Inkoplistan.Data.InkoplistanContext _context;

        public CreateModel(Inkoplistan.Data.InkoplistanContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Matvara Matvara { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Matvara.UserId = User.Identity.Name;

            _context.Matvara.Add(Matvara);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
