using gratchLib.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gratchLib.DAL.Configurations
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
