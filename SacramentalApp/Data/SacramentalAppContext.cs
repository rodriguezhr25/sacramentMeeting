using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using SacramentalApp.Models;

namespace SacramentalApp.Data

{
    public class SacramentalAppContext : DbContext
    {
        public SacramentalAppContext(DbContextOptions<SacramentalAppContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentalApp.Models.Meeting> Meeting { get; set; }
        public DbSet<SacramentalApp.Models.Speech>  Speech { get; set; }
        public DbSet<SacramentalApp.Models.MusicSelection> MusicSelection { get; set; }
    }
}

