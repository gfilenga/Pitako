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

            modelBuilder.Entity<Answer>()
            .HasOne<User>(u => u.User)
            .WithMany(q => q.Answers)
            .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Answer>()
            .HasOne<Question>(u => u.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(u => u.QuestionId);

            modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(124);
            modelBuilder.Entity<User>().Property(x => x.Username).HasMaxLength(20);
            modelBuilder.Entity<User>().Property(x => x.Password).HasMaxLength(20);
            modelBuilder.Entity<User>().Property(x => x.Role).HasMaxLength(6);



            modelBuilder.Entity<Question>().Property(x => x.Title).HasMaxLength(124);
            modelBuilder.Entity<Question>().Property(x => x.Description).HasMaxLength(1024);



            modelBuilder.Entity<Answer>().Property(x => x.Description).HasMaxLength(1024);
        }
    }
}