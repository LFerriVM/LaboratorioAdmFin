using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Models;

namespace Data;

public class DataContext : DbContext
{
    public DbSet<Itens> Itens { get; set; }

    public DataContext()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=data.db");
}
