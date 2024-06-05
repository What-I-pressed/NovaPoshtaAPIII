using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovaPoshtaAPIBleBla.Entities;

namespace Infrastructure.Data
{
    public class NovaPoshDbContext : DbContext
    {
        public DbSet<CityEntity> tblCities { get; set; }
        
        public DbSet<AreaEntity> tblAreas { get; set; }

        public DbSet<PostOfficeEntity> tblPostOffices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(AppDatabase.connectionSting);
            
        }
    }
}
