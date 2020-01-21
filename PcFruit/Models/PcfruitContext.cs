using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcFruit.Models
{
    public class PcfruitContext: DbContext
    {
        public PcfruitContext(DbContextOptions<PcfruitContext> options)
            :base(options)
        { }
        public DbSet<Meter> Meters { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meter>().ToTable("metingen");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
