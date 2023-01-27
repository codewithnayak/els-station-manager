using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StationManagerApi.Db
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(_ => _.Id).UseIdentityColumn(1, 1);
            builder.Property(_ => _.City).IsRequired().HasMaxLength(200);
            builder.Property(_ => _.District).IsRequired().HasMaxLength(200);
            builder.Property(_ => _.BuildingName).HasMaxLength(200);
        }
    }
}