using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inkoplistan.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Inkoplistan.Pages
{
    public class ProvaModel : PageModel
    {

        private readonly Data.InkoplistanContext _context;
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public IList<Matvara> Matvara { get; set; }
        public ProvaModel(Data.InkoplistanContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Matvara = await _context.Matvara.ToListAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            foreach (var pro in Matvara)  //esplora tutta la lista MATVARA e aggiorna il database per le righe(pro) modificate
            {
                _context.Entry(pro).State = EntityState.Modified;
                _context.Update(pro);
            }
                await _context.SaveChangesAsync();

            return RedirectToPage("./index");
        }
    }
}
