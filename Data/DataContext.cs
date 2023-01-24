using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task.Entities;

namespace task.Data
{
    public class DataContext: DbContext
    {
        
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

         protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Game>()
                .Property(e => e.platforms)
                .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            
        }
    }
    
}