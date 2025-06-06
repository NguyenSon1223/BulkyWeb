﻿using BulkyWeb_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options ) : base ( options)
        {

        }
        
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1 , Name = "Scifi" , DisplayOrder = 1},
                new Category { Id =  2 , Name = "Action", DisplayOrder = 2 }
                );
        }
    }
}
