using AppShop.Business.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShop.Business.Mapping
{

    public class AppShopDBContext : DbContext
    {  
        public AppShopDBContext(DbContextOptions<AppShopDBContext> options): base(options)
    { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderBuy> OrderBuys { get; set; }
        public DbSet<Log> Logs  { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //  optionsBuilder.UseSqlServer("data source=.\\SQLEXPRESS;initial catalog=ShopElectro;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
        //    Configuration.GetConnectionString("Connection");


        //}
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new OrderBuyMapping());
            modelBuilder.ApplyConfiguration(new LogMapping());
        }
    }
}
