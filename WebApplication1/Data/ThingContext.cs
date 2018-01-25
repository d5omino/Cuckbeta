using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class ThingContext : DbContext
    {
        public ThingContext (DbContextOptions<ThingContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Thing> Thing { get; set; }
    }
}
