using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class NovaPoshDbContext : DbContext
    {
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<AreaEntity> Areas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(AppDatabase.connectionSting);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
