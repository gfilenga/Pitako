using Microsoft.EntityFrameworkCore;
using Pitako.Domain.Entities;

namespace Pitako.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
            .HasOne<User>(u => u.User)
            .WithMany(q => q.Questions)
            .HasForeignKey(u => u.UserId);
        }
    }
}