
using Microsoft.EntityFrameworkCore;

namespace SimpleApp.Database.Models
{
    public class SimpleAppContext : DbContext
    {
        public SimpleAppContext(DbContextOptions<SimpleAppContext> options) : base(options) { }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<Emails> Emails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Entity One-to-many
            //Person - Emails
            modelBuilder.Entity<Emails>()
                .HasOne(U => U.Person)
                .WithMany(r => r.Emails)
                .HasForeignKey(R => R.PersonId);
        }
    }
}
