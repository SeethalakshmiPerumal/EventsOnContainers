using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class CatalogContext:DbContext
    {
        //constructor with passing options param
        public CatalogContext(DbContextOptions options)
            :base(options)
        {

        }

        //creating db set tablesname
        public DbSet<CatalogLocation> CatalogLocations { get; set; }
        public DbSet<CatalogEvent> CatalogEvents { get; set; }
        //creation of each column name in table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogLocation>(ConfigureCatalogLocation);
            modelBuilder.Entity<CatalogEvent>(ConfigureCatalogEvent);
        }

        private void ConfigureCatalogEvent(EntityTypeBuilder<CatalogEvent> builder)
        {
            builder.ToTable("CatalogEvents");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_event_hilo");
            builder.Property(c => c.EventName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Date)
                .IsRequired()
                .IsFixedLength();
            builder.Property(c => c.Time)
                .IsRequired()
                .IsFixedLength();
            builder.Property(c => c.Price)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.PictureUrl)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.ContactNum)
                .IsRequired()
                .IsFixedLength();
            builder.Property(c => c.ContactName)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasOne(c => c.CatalogLocation)
                .WithMany()
                .HasForeignKey(c => c.CatalogLocationId);
                       
                }

        private void ConfigureCatalogLocation(EntityTypeBuilder<CatalogLocation> builder)
        {
            builder.ToTable("CatalogLocations");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_location_hilo");
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.City)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Zipcode)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
