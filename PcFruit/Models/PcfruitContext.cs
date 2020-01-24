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
        public DbSet<Sensor> Meters { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensor>().ToTable("sensors");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Module>().ToTable("modules");
            modelBuilder.Entity<NotificationSettings>().ToTable("notificationSettings");
            modelBuilder.Entity<Notification>().ToTable("notifications");
        }

        public DbSet<PcFruit.Models.Module> Modules { get; set; }

        public DbSet<PcFruit.Models.Measurement> Measurements { get; set; }
    }
}
