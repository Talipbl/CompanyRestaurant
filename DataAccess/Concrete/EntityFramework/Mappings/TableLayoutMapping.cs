using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class TableLayoutMapping : IEntityTypeConfiguration<TableLayout>
    {
        public void Configure(EntityTypeBuilder<TableLayout> builder)
        {
            builder.HasKey(x => x.LayoutID);
            builder.Property(x => x.LayoutPath).IsRequired();
        }
    }
}
