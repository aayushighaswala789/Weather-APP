using Microsoft.EntityFrameworkCore;
using System;
using WeatherForecast.Core.Entities;

namespace WeatherForecast.Infrastructure.Data
{
    public class WeatherForecastDbContext : DbContext
    {
        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options)
          : base(options)
        {

        }

        public DbSet<WeatherCast> WeatherForecasts { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }

        public DbSet<ForecastDetail> ForecastDetails { get; set; }

        public DbSet<UnitMeasure> UnitMeasures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "ft", 0));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "in", 1));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "mi", 2));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "mm", 3));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "cm", 4));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "m", 5));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "km", 6));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "km/h", 7));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "kt", 8));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "mi/h", 9));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "m/s", 10));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "hPa", 11));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "Hg", 12));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "kPa", 13));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "mbar", 14));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "mmHg", 15));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "psi", 16));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "C", 17));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "F", 18));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "K", 19));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "%", 20));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "f", 21));
            modelBuilder.Entity<UnitMeasure>().HasData(new UnitMeasure(Guid.NewGuid(), "int", 22));
        }

    }
}
