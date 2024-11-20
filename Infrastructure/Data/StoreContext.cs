using System;
using Core.Entities;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreContext(DbContextOptions options) : DbContext(options) // as options we need to pass the SQL Server connection String
{
    /*
        DbContext:
        actúa como un puente entre tu aplicación .NET y la base de datos, 
        permitiéndo realizar operaciones CRUD (Crear, Leer, Actualizar y Borrar)
    */
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Applies the new Property configuration from "class ProductConfiguration"
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
    }
}
