using Microsoft.EntityFrameworkCore;
using ZDZCode_Api.Src.Domain.Entities;

namespace ZDZCode_Api.Src.Infrastructure.Database
{
    public class DbAdapter(DbContextOptions<DbAdapter> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BillsEntity> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasKey(u => u.email);

            modelBuilder.Entity<BillsEntity>()
                .HasKey(b => b.id);

            modelBuilder.Entity<BillsEntity>()
                .HasOne(a => a.user)
                .WithMany(u => u.bills)
                .HasForeignKey(b => b.userEmail);
        }
    }
}