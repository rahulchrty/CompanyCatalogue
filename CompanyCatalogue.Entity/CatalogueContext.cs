using CompanyCatalogue.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyCatalogue.Entity
{
    public class CatalogueContext : DbContext
    {
        public CatalogueContext(DbContextOptions<CatalogueContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<CompanyDetail> CompanyDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<CompanyDetail>()
                .HasOne(x => x.Catalogue)
                .WithMany(y => y.CompanyDetails)
                .HasForeignKey(z => z.CatalogueId)
                .HasConstraintName("FK_Catalogue_CatalogueId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
