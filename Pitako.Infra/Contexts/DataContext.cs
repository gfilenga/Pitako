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
            // modelBuilder.Entity<Question>().Property(x => x.Id);
            // modelBuilder.Entity<Question>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
            // modelBuilder.Entity<Question>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
            // modelBuilder.Entity<Question>().Property(x => x.Done).HasColumnType("bit");
            // modelBuilder.Entity<Question>().Property(x => x.Date);
            // modelBuilder.Entity<Question>().HasIndex(b => b.User);
        }
    }
}