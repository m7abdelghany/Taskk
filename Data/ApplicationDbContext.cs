using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Taskk.Models;

namespace Taskk.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DebtMangment>()
                .HasMany(o => o.DebtCalc)
                .WithOne(od => od.Mangments)
                .HasForeignKey(od => od.DebtID)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<DebtCalculation> debtCalculations { get; set; }
        public DbSet<DebtMangment> debtMangments { get;set; }
    }
}