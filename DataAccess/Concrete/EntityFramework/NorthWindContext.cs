using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: Db tabloları ile proje classlarını ilişkilendirmek
    public class NorthWindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }
        //Hangi classım hangi tabloya karşılık geliyor.
        public DbSet<Product> Products { get; set; } //Ürünü ürünlere bağla
        public DbSet<Category> Categories { get; set; } //Kategoriyi kategorilere bağla
        public DbSet<Customer> Customers { get; set; } //Müşteriyi müştterilere bağla
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
