using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class StoreContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Client>(entity =>
        //    {
        //        entity.HasKey(e => e.Id);
        //        entity.Property(e => e.Name).IsRequired();
        //        entity.Property(e => e.Email).IsRequired();
        //        entity.Property(e => e.BirthDate).IsRequired(false);
        //    });
        //}
    }
}
