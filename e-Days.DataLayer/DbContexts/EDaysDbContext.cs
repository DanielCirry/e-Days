using e_Days.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Days.DataLayer.DbContexts
{
    public class EDaysDbContext : DbContext
    {
        public DbSet<MessageOfTheDay> MessageOfTheDays { get; set; }

        public EDaysDbContext(DbContextOptions<EDaysDbContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MessageOfTheDay>()
                .HasKey(k => new { k.Day });
        }
    }
}
