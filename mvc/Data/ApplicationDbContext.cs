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
            
        }
    }
}