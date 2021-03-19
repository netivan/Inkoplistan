using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inkoplistan.Models;

namespace Inkoplistan.Data
{
    public class InkoplistanContext : DbContext
    {
        public InkoplistanContext (DbContextOptions<InkoplistanContext> options)
            : base(options)
        {
        }

        public DbSet<Inkoplistan.Models.Matvara> Matvara { get; set; }
    }
}
