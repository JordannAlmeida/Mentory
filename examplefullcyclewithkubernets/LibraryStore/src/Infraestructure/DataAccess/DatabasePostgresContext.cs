namespace Infraestructure.DataAccess
{
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    public sealed class DatabasePostgresContext : DbContext
    {

        public DatabasePostgresContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
                throw new ArgumentNullException(nameof(modelBuilder));
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabasePostgresContext).Assembly);
        }


    }
}