using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCapProjectDb;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User/*burası aynı olmasada olur*/> Users/*normalde burası veri tabanıyla aynı olma zorundak*/ { get; set; }//birde burası User olarak yazılır 
        public DbSet<Customer> Customers { get; set; }//o zaman böyle olmalı çünkü vt de bu şekilde adı
        public DbSet<Rental> Rentals { get; set; }
    }
}
