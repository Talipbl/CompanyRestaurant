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
            //optionsBuilder.UseSqlServer("Server=talipbl.xyz.\\MSSQLSERVER2014; Database=moqmwegx_; Uid=admin; Pwd=Klbw34*1;");
            optionsBuilder.UseSqlServer("Server=DESKTOP-R2TQ29K; Database=CompanyRestaurant; Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<OrderDetail>(new OrderDetailMapping());
            modelBuilder.ApplyConfiguration<RecipeProduct>(new RecipeProductMapping());
            modelBuilder.ApplyConfiguration<Category>(new CategoryMapping());
            modelBuilder.ApplyConfiguration<Product>(new ProductMapping());
            //modelBuilder.ApplyConfiguration<StockUnit>(new StockUnitMapping());

            modelBuilder.ApplyConfiguration<OperationClaim>(new OperationClaimMapping());
            modelBuilder.ApplyConfiguration<PersonClaim>(new PersonClaimMapping());

            modelBuilder.ApplyConfiguration<TableLayout>(new TableLayoutMapping());
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeProduct> RecipesProducts { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        //public virtual DbSet<StockUnit> StockUnits { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<TableLayout> TableLayouts { get; set; }


        public virtual DbSet<OperationClaim> Claims { get; set; }
        public virtual DbSet<PersonClaim> PersonClaims { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
    }
}
