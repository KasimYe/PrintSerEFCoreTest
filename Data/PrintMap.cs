using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintSerApp.Entities;

namespace PrintSerApp.Data
{
    internal class PrintMap : IEntityTypeConfiguration<PrintEntity>
    {
        public void Configure(EntityTypeBuilder<PrintEntity> builder)
        {
            builder.ToTable($"{nameof(PrintEntity)}");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.CreateTime).HasDefaultValue(DateTime.Now);
        }
    }
}