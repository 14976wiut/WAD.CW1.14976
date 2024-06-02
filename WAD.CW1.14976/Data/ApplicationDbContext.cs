using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using WAD.CW1._14976.Models;

namespace WAD.CW1._14976.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and any additional configurations
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            // Seed data (optional)
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Author 1", DateOfBirth = new DateTime(1970, 1, 1), Nationality = "American" },
                new Author { Id = 2, Name = "Author 2", DateOfBirth = new DateTime(1980, 1, 1), Nationality = "British" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Book 1", AuthorId = 1, PublicationYear = 1990, Genre = "Fiction" },
                new Book { Id = 2, Title = "Book 2", AuthorId = 2, PublicationYear = 2000, Genre = "Non-Fiction" }
            );
        }
    }
}
