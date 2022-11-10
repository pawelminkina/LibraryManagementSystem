using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.DbContexts.Configurations.ApplicationDbContextConfiguration;

public class LibraryGroupEntityConfiguration : IEntityTypeConfiguration<LibraryGroup>
{
    public void Configure(EntityTypeBuilder<LibraryGroup> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name);

        builder.HasMany(s => s.Libraries)
            .WithOne(s => s.LibraryGroup)
            .HasForeignKey(s => s.LibraryGroupId);

        builder.HasData(new[]
        {
            new LibraryGroup()
            {
                Id = Guid.Parse("e7b2e4ff-9c8a-45c4-aec5-f949d419b9c0"),
                Name = "Group 1"
            },
            new LibraryGroup()
            {
                Id = Guid.Parse("7e281174-5f21-497b-a1ff-641ac1aff60e"),
                Name = "Group 2"
            }
        });
    }
}