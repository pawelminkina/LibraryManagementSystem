using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Infrastructure.DbContexts.Configurations.ApplicationDbContextConfiguration;

public class BookEntityConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Title).IsRequired();

        builder.HasOne(s => s.Library)
            .WithMany(s => s.Books)
            .HasForeignKey(s => s.LibraryId);

        builder.HasData(
            new Book()
            {
                Id = Guid.Parse("f0811a4e-628a-4e9b-98da-9e5523f1a6d3"),
                Title = "Some book 1",
                LibraryId = Guid.Parse("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb")
            },
            new Book()
            {
                Id = Guid.Parse("73e03a55-d760-4415-aeb5-743e9dd79f20"),
                Title = "Some book 2",
                LibraryId = Guid.Parse("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb")
            },
            new Book()
            {
                Id = Guid.Parse("2ce20daa-4315-4a1d-b555-5a1d337de520"),
                Title = "Some book 3",
                LibraryId = Guid.Parse("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb")
            },
            new Book()
            {
                Id = Guid.Parse("49b1ba68-e260-4a7e-9e3f-da55f79c90f4"),
                Title = "Some book 4",
                LibraryId = Guid.Parse("adea7009-34c0-4aa4-8284-d76757d2d5f2")
            },
            new Book()
            {
                Id = Guid.Parse("dd582fe1-1b4b-4c10-910e-e41c8b78d30c"),
                Title = "Some book 5",
                LibraryId = Guid.Parse("adea7009-34c0-4aa4-8284-d76757d2d5f2")
            },
            new Book()
            {
                Id = Guid.Parse("ac64849c-a923-4346-a2ad-6fa9d19cd2be"),
                Title = "Other some book 1",
                LibraryId = Guid.Parse("adea7009-34c0-4aa4-8284-d76757d2d5f2")
            },
            new Book()
            {
                Id = Guid.Parse("3efa03c9-c526-46ed-9808-835fd44a646e"),
                Title = "Other some book 2",
                LibraryId = Guid.Parse("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea")
            },
            new Book()
            {
                Id = Guid.Parse("73eddf44-edc3-441f-8366-27cdf6595bc7"),
                Title = "Other some book 3",
                LibraryId = Guid.Parse("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea")
            },
            new Book()
            {
                Id = Guid.Parse("4f47a31e-3a6b-4b61-8061-95c6619ae4f6"),
                Title = "Other some book 4",
                LibraryId = Guid.Parse("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea")
            });
    }
}