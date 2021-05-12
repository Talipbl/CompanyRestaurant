using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class RecipeProductMapping : IEntityTypeConfiguration<RecipeProduct>
    {
        public void Configure(EntityTypeBuilder<RecipeProduct> builder)
        {
            builder.HasKey(x => new { x.RecipeID, x.ProductID });
            builder.Property(x => x.Quantity).IsRequired();
        }
    }
}
