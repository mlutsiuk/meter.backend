﻿using Microsoft.EntityFrameworkCore;

namespace Meter.Models;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Counter> Counters { get; set; }
    public DbSet<Measure> Measures { get; set; }
    public DbSet<Icon> Icons { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        //Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        Role adminRole = new Role { Id = 1, Name = "admin" };
        Role userRole = new Role { Id = 2, Name = "user" };
        User maksym = new User
            { Id = 1,Name = "mlutsiuk", Email = "maksym.lutsiuk@oa.edu.ua", Password = "12345678", Avatar = null, RoleId = adminRole.Id };
        User anna = new User
            { Id = 2, Name = "AnechkaR", Email = "anna.romaniuk@oa.edu.ua", Password = "qwertyui", Avatar = null, RoleId = adminRole.Id };

        modelBuilder.Entity<Role>().HasData(adminRole, userRole);
        modelBuilder.Entity<User>().HasData(maksym, anna);
        
        base.OnModelCreating(modelBuilder);
    }
}