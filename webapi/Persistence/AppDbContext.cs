using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Mark> Marks { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Subject>()
                .HasMany(p => p.Marks)
                .WithOne(p => p.Subject)
                .HasForeignKey(a => a.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                .HasMany(d => d.Marks)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Mark>()
                .HasKey(a => a.Id);
        }
    }
}
