using Microsoft.EntityFrameworkCore;

using System.Reflection;
using TesodevCase.Entities;

namespace TesodevCase.DAL.Context
{
    public class CustomerDbContext :DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer
            ("Server =(localdb)\\MSSqlLocalDb; Database=Tesodev; Trusted_Connection=True;TrustServerCertificate=true");
            // burada ben sql server database provider kullandim ve kendi lokalimda database i kurdum.
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // entityconfig klasorumuzun icinde yaptigimiz entitlerdeki tum ayarlari ef core ile uygulamamizi saglar.
            
            //modelBuilder.Entity<Address>().ToTable("Address");
            //modelBuilder.Entity<Customer>().ToTable("Customer");
            //modelBuilder.Entity<Order>().ToTable("Order");
            //modelBuilder.Entity<Product>().ToTable("Product");

          

        }

    }
}
