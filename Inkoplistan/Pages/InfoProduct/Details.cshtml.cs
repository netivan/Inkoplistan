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
    public class DetailsModel : PageModel
    {
        private readonly Inkoplistan.Data.InkoplistanContext _context;

        public DetailsModel(Inkoplistan.Data.InkoplistanContext context)
        {
            _context = context;
        }

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
    }
}
