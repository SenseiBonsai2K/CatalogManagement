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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Username).IsRequired().HasMaxLength(20);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);

            builder.Property(u => u.Password).IsRequired().HasMaxLength(200);

            builder.Property(u => u.Role).IsRequired().HasMaxLength(20);
        }
    }
}
