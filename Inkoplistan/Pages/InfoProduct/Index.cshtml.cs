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
    public class IndexModel : PageModel
    {
        private readonly Inkoplistan.Data.InkoplistanContext _context;

        public IndexModel(Inkoplistan.Data.InkoplistanContext context)
        {
            _context = context;
        }

        public IList<Matvara> Matvara { get;set; }

        public async Task OnGetAsync()
        {
            Matvara = await _context.Matvara.ToListAsync();
        }
    }
}
