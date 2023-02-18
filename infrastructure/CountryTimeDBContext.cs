using e08.domain.model;
using Microsoft.EntityFrameworkCore;

namespace e08.infrastructure;

public class CountryTimeDBContext : DbContext
{

    public DbSet<CityTime>? CityTimes { get; set; }

    public string DbPath { get; }

    public CountryTimeDBContext() // Review this warning
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "city_times.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder builder)
        => builder.Entity<CityTime>().HasKey(d => d.City);
}