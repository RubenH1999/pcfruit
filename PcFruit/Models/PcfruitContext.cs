using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PcFruit.Models;

namespace PcFruit.Models
{
    public class PcfruitContext: DbContext
    {
        public PcfruitContext(DbContextOptions<PcfruitContext> options)
            :base(options)
        { }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Measurement> Measurements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensor>().ToTable("sensors");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Module>().ToTable("modules");
            modelBuilder.Entity<Spec>().ToTable("sensorspecs");
            modelBuilder.Entity<Measurement>().ToTable("measurements");
            modelBuilder.Entity<Module>().ToTable("modules");
            
            // define many to many relationship
            modelBuilder
                .Entity<SensorSpec>()
                .HasKey(s => new { s.SpecID, s.SensorID });

            // define foreign key
            modelBuilder.Entity<SensorSpec>()
                .HasOne(s => s.Sensor)
                .WithMany(s => s.SensorSpecs)
                .HasForeignKey(s => s.SensorID);

            // define other foreign key
            modelBuilder.Entity<SensorSpec>()
                .HasOne(s => s.Spec)
                .WithMany(s => s.SensorsSpecs)
                .HasForeignKey(s => s.SpecID);
        }

       
    }
}
