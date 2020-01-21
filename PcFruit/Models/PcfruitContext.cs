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
        public DbSet<Dendrometer> Dendrometers { get; set; }
        public DbSet<Thermometer> Thermometers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dendrometer>().ToTable("Dendrometer");
            modelBuilder.Entity<Thermometer>().ToTable("Thermometer");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
