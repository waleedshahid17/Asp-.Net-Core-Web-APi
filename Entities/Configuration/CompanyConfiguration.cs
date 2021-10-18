using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData
            (
            new Company
            {
                id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                name = "IT_Solutions Ltd",
                address = "583 Wall Dr. Gwynn Oak, MD 21207",
                country = "USA"
            },
            new Company
            {
                id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                name = "Admin_Solutions Ltd",
                address = "312 Forest Avenue, BF 923",
                country = "USA"
            }
            );
        }
    }
}

