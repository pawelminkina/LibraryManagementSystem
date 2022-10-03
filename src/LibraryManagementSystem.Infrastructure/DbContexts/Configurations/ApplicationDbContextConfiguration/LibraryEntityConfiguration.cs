using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.DbContexts.Configurations.ApplicationDbContextConfiguration;

public class LibraryEntityConfiguration : IEntityTypeConfiguration<Library>
{
    public void Configure(EntityTypeBuilder<Library> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name);

        builder.HasData(new[]
        {
            new Library()
            {
                Id = Guid.Parse("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb"),
                Name = "Library one"
            },

            new Library()
            {
                Id = Guid.Parse("adea7009-34c0-4aa4-8284-d76757d2d5f2"),
                Name = "Library two"
            },

            new Library()
            {
                Id = Guid.Parse("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea"),
                Name = "Library three"
            },
        });
    }
}