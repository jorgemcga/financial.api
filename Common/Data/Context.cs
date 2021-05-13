using Microsoft.EntityFrameworkCore;
using Financial.API.Common.Entities;

namespace Financial.API.Common.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public virtual DbSet<ExpiredTitleEntity> ExpiredTitle { get; set; }
        public virtual DbSet<ExpiredTitlePortionEntity> Portion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpiredTitleEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasMany(e => e.Portions)
                      .WithOne(e => e.ExpiredTitle)
                      .HasForeignKey(e => e.ExpiredTitleId);
            });

            modelBuilder.Entity<ExpiredTitlePortionEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.ExpiredTitle)
                      .WithMany(e => e.Portions)
                      .HasForeignKey(e => e.ExpiredTitleId);
            });
        }
    }
}
