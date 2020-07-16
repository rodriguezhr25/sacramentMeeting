using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SacramentalApp.Models
{
    public class SacramentalAppContext : DbContext
    {
        public SacramentalAppContext(DbContextOptions<SacramentalAppContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentalApp.Models.Meeting> Meeting { get; set; }
    }
}
