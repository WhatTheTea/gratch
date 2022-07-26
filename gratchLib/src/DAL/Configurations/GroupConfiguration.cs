using gratch.Library;
using gratch.Library.Arrangement;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gratch.Library.DAL.Configurations
{
    internal class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            //var serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.General);

            builder.Ignore(p => p.ArrangedPeople);

            builder.Property(p => p.Arrangement)
                   .HasConversion(
                        p => p.GetType().Name,
                        p => ArrangementFromString(p)
                   );
        }

        private IArrangement ArrangementFromString(string @string)
        {
            return @string switch
            {
                nameof(BaseArrangement) => new BaseArrangement(),
                nameof(OneByOneArrangement) => new OneByOneArrangement(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
