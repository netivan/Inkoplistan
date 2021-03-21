using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inkoplistan.Models;
using Microsoft.EntityFrameworkCore;

namespace Inkoplistan.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Data.InkoplistanContext _context;

        public IndexModel(Data.InkoplistanContext context)
        {
            _context = context;
        }

        public IList<Matvara> Matvaror { get; set; }     // Matvaror är en lista som innehåller all data (varorna) hämtade med OnGet
        

        public async Task<IActionResult> OnGetAsync()    
        {

            Matvaror = await _context.Matvara.ToListAsync();   // Här laddas in (loads) i listan varorna 

            return Page();

        }
    }
}
