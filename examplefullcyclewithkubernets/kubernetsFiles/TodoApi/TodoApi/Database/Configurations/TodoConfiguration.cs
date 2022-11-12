using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoApi.Database.Generators;
using TodoApi.Entities;

namespace TodoApi.Database.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .UseIdentityAlwaysColumn();

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(p => p.CreateAt)
                .IsRequired()
                .HasColumnType("Timestamp")
                .HasValueGenerator<DateTimeNowGenerator>();

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<Todo> builder)
        {
            builder.HasData
            (
                Enumerable.Range(1, 10000).Select(i => new Todo
                {
                    Id = i,
                    Description = $"Test {i}"
                })
            );
        }
    }
}
