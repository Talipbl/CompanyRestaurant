using Core.Entities;
using DataAccess.Concrete.EntityFramework.Mappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class CompanyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-R2TQ29K; Database=CompanyRestaurant; Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<UserClaim>(new UserClaimMapping());
            modelBuilder.ApplyConfiguration<OrderDetail>(new OrderDetailMapping());
            modelBuilder.ApplyConfiguration<RecipeProduct>(new RecipeProductMapping());
            modelBuilder.ApplyConfiguration<Category>(new CategoryMapping());
            modelBuilder.ApplyConfiguration<Product>(new ProductMapping());
            modelBuilder.ApplyConfiguration<StockUnit>(new StockUnitMapping());
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeProduct> RecipesProducts { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<StockUnit> StockUnits { get; set; }
        public virtual DbSet<Table> Tables { get; set; }


        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
