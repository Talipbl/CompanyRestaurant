using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class OrderDetailMapping : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => new { x.OrderID, x.ProductID });
            builder.Property(x => x.Quantity).HasColumnType("float").IsRequired();
            builder.Property(x => x.Amount).HasColumnType("money").IsRequired();
            builder.Property(x => x.UnitId).HasColumnType("int").IsRequired();
        }
    }
}
