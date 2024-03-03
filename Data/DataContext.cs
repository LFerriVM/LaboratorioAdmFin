using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Models;

namespace Data;

public class DataContext : DbContext
{
    public DbSet<Itens> Itens { get; set; }
    public DbSet<Balancos> Balancos { get; set; }
    public DbSet<ItensBalancos> ItensBalancos { get; set; }

    public DataContext()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=data.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItensBalancos>().HasKey(ib => new { ib.IdItem, ib.IdBalanco });
    }
}
