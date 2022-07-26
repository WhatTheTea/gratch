using gratch.Library;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gratch.Library.DAL.Configurations
{
    internal class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            builder.Property(x => x.Date)
                   .HasConversion(d => DateOnly.FromDateTime(d),
                                  d => d.ToDateTime(TimeOnly.MinValue));
            builder.Property(x => x.Name)
                   .HasField("_name");
        }
    }
}
