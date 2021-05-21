using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using StoreApp.Domain;

namespace StoreApp.Data
{
    public class DepartmentContext : DbContext
    {
        public DbSet<Staff> staff { get; set; }
        public DbSet<Address> address { get; set; }
        public DbSet<Role> role { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Supplier> supplier { get; set; }
        public DbSet<PurchaseOrder> porder { get; set; }

        public DbSet<Inventory> inventory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;DataBase=store; username=postgres;password=root123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Staff>().HasKey(r => r.staff_id);
            modelBuilder.Entity<Staff>().Property(x => x.Staff_name).HasMaxLength(64);
            modelBuilder.Entity<Staff>().Property(x => x.phone_no).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Staff>().HasOne(s => s.addresses).WithMany(a => a.Staff).HasForeignKey(x => x.address_id);
            modelBuilder.Entity<Staff>().HasOne(s => s.roles).WithMany(a => a.Staff).HasForeignKey(x => x.role_id);


            modelBuilder.Entity<Role>().HasKey(r => r.role_id);
            modelBuilder.Entity<Role>().Property(x => x.name).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Role>().Property(x => x.description).HasMaxLength(64).IsRequired();


            modelBuilder.Entity<Address>().HasKey(r => r.address_id);
            modelBuilder.Entity<Address>().Property(x => x.addressLine_1).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Address>().Property(x => x.city).HasMaxLength(10);
            modelBuilder.Entity<Address>().Property(x => x.state).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Address>().Property(x => x.pincode).HasMaxLength(10).IsRequired();


            modelBuilder.Entity<Product>().HasKey(r => r.product_id);
            modelBuilder.Entity<Product>().Property(x => x.name).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.manufacturer).HasMaxLength(10);
            modelBuilder.Entity<Product>().Property(x => x.sellingPrice).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.costPrice).IsRequired();
            modelBuilder.Entity<Product>().HasOne(s => s.categories).WithMany(a => a.Product).HasForeignKey(x => x.category_id);


            modelBuilder.Entity<Category>().HasKey(r => r.category_id);
            modelBuilder.Entity<Category>().Property(x => x.cat_name).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Category>().Property(x => x.cat_code).HasMaxLength(10).IsRequired();


            modelBuilder.Entity<Supplier>().HasKey(r => r.supplier_id);
            modelBuilder.Entity<Supplier>().Property(x => x.supplier_id).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Supplier>().Property(x => x.phone_no).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Supplier>().Property(x => x.email).IsRequired().HasMaxLength(64);
            modelBuilder.Entity<Supplier>().Property(x => x.city).HasMaxLength(15);



            modelBuilder.Entity<PurchaseOrder>().HasKey(x => new { x.supplier_id, x.product_id });
            modelBuilder.Entity<PurchaseOrder>().Property(x => x.supply_date).IsRequired();
            modelBuilder.Entity<PurchaseOrder>().HasOne(x => x.suppliers).WithMany(a => a.PurchaseOrders).HasForeignKey(x => x.supplier_id);
            modelBuilder.Entity<PurchaseOrder>().HasOne(x => x.products).WithMany(a => a.purchaseorder).HasForeignKey(x => x.product_id);



            modelBuilder.Entity<Inventory>().Property(x => x.quantity).IsRequired();
            modelBuilder.Entity<Inventory>().HasOne(x => x.product).WithOne().HasForeignKey<Inventory>(i => i.product_id);
            modelBuilder.Entity<Inventory>().HasKey(x => x.product_id);

        }
    }
}
