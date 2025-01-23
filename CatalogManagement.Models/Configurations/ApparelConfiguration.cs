using CatalogManagement.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Models.Configurations
{
    public class ApparelConfiguration : IEntityTypeConfiguration<Apparel>
    {
        public void Configure(EntityTypeBuilder<Apparel> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Name).IsRequired().HasMaxLength(30);

            builder.Property(a => a.Description).HasMaxLength(300);

            builder.Property(a => a.ImageUrl).HasMaxLength(200);

            builder.Property(a => a.Size).HasMaxLength(10);

            builder.Property(a => a.Material).HasMaxLength(50);

            builder.Property(a => a.Brand).HasMaxLength(50);

            builder.Property(a => a.Price).IsRequired();

            builder.Property(a => a.Stock).IsRequired();

            builder.HasOne(a => a.Category)
                   .WithMany(c => c.Apparels)
                   .HasForeignKey(a => a.CategoryId);
        }
    }
}
