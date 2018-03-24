using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }

        public DbSet<Product> Products { get;set;}
        public DbSet<Category> Categories { get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Product>().ToTable("product");
            modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(100).HasColumnName("name");
            modelBuilder.Entity<Category>().ToTable("category");
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(50).HasColumnName("name");
        }
    }
}