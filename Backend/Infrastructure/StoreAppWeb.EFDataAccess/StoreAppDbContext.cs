using Microsoft.EntityFrameworkCore;
using StoreAppWeb.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAppWeb.EFDataAccess
{
    public class StoreAppDbContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptItem> ReceiptItems { get; set; }
        public StoreAppDbContext(DbContextOptions<StoreAppDbContext> options) : base(options)
        {             
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Store>()
                .HasMany(p => p.CashRegisters)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
                /*builder.Entity<Store>()
                .HasMany(p => p.CashRegisters)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetPropertyAccessMode(PropertyAccessMode.Field);*/




        }

    }
}
