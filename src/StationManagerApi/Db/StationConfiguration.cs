using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StationManagerApi.Db
{
    internal class StationConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.Property(_ => _.Name).
                IsRequired()
                .HasMaxLength(200);

            builder.Property( _ => _.StationCode).
               IsRequired()
               .HasMaxLength(200);

            builder.Property(_ => _.Id).UseIdentityColumn(1,1);
            builder.Property(_ => _.StationIdentifier).IsRequired();
            builder.Navigation(_ => _.Address).IsRequired();
        }
    }
}