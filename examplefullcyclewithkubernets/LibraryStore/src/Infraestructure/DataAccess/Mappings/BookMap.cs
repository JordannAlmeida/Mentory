using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .ToTable("BOOK")
                .HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Title).HasColumnName("TITLE").IsRequired();
            builder.Property(x => x.Author).HasColumnName("AUTHOR").IsRequired();
            builder.Property(x => x.CreatedDate).HasColumnName("CREATED_DATE");
            builder.Property(x => x.Price).HasPrecision(2).HasColumnName("PRICE").IsRequired();
            builder.Property(x => x.PageNumber).HasColumnName("PAGE_NUMBER").IsRequired();
        }
    }
}
