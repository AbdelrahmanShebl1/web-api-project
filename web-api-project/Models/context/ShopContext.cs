using Microsoft.EntityFrameworkCore;
using web_api_project.Models;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Electro_Project.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace web_api_project.Models.context
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Mobile> Phones { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<MobilesAndAccessories>().ToTable("Mobile");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");
            modelBuilder.Entity<Mobile>().ToTable("Phone");

            base.OnModelCreating(modelBuilder); /// For IdentityDbContext Mapping
        }

    }
}
