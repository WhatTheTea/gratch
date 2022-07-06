using gratchLib.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Text.Json;

namespace gratchLib.DAL.Configurations
{
    internal class CalendarConfiguration : IEntityTypeConfiguration<Calendar>
    {
        public void Configure(EntityTypeBuilder<Calendar> builder)
        {
            var serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.General);

            builder.Property(x => x.Weekend)
                   .HasConversion(
                        v => JsonSerializer.Serialize(v, serializerOptions),
                        v => JsonSerializer.Deserialize<IList<DayOfWeek>>(v, serializerOptions) ?? new List<DayOfWeek>());
            builder.Property(x => x.StartDate)
                   .HasConversion(d => DateOnly.FromDateTime(d),
                                  d => d.ToDateTime(TimeOnly.MinValue));
        }
    }
}
