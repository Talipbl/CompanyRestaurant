using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class StockUnitMapping : IEntityTypeConfiguration<StockUnit>
    {
        public void Configure(EntityTypeBuilder<StockUnit> builder)
        {
            builder.HasKey(x => x.UnitID);
            builder.Property(x => x.UnitType).IsRequired();
        }
    }
}
