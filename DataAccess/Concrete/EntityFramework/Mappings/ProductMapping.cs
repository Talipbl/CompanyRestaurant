using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductID);
            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.CategoryId).HasColumnType("int").IsRequired();
            builder.Property(x => x.UnitPrice).HasColumnType("money").IsRequired();
            builder.Property(x => x.UnitsInRestaurantStock).HasColumnType("float");
            builder.Property(x => x.UnitsInWarhouseStock).HasColumnType("float");
            //builder.HasOne<Category>(c=>c.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            //builder.HasOne<StockUnit>().WithMany(x => x.Products).HasForeignKey(x => x.UnitId);
            
        }
    }
}
