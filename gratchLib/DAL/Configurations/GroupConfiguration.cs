using gratchLib.Entities;
using gratchLib.Entities.Arrangement;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace gratchLib.DAL.Configurations
{
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            //var serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.General);

            builder.Ignore(p => p.ArrangedPeople);

            builder.Property(p => p.Arrangement);
        }

    }
}
