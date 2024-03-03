using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using admfin.Models;

namespace Data;

public class DataContext : DbContext
{
    public DbSet<Item> Itens { get; set; }
    public DbSet<Balanco> Balancos { get; set; }
    // public DbSet<ItensBalancos> ItensBalancos { get; set; }

    public DataContext()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=data.db");

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<ItensBalancos>().HasKey(ib => new { ib.IdItem, ib.IdBalanco });
    // }
}
