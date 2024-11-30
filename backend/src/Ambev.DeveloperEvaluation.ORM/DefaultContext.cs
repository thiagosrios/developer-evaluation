﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Branch> Branchs { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleItem> SaleItems { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}

public class DatabaseContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DefaultContext>();
        optionsBuilder.UseNpgsql();

        return new DefaultContext(optionsBuilder.Options);
    }
}

//public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
//{
//    public DefaultContext CreateDbContext(string[] args)
//    {
//        IConfigurationRoot configuration = new ConfigurationBuilder()
//            .SetBasePath(Directory.GetCurrentDirectory())
//            .AddJsonFile("appsettings.json")
//            .Build();

//        var builder = new DbContextOptionsBuilder<DefaultContext>();
//        var connectionString = configuration.GetConnectionString("DefaultConnection");

//        builder.UseNpgsql(
//               connectionString,
//               b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.WebApi")
//        );

//        return new DefaultContext(builder.Options);
//    }
//}