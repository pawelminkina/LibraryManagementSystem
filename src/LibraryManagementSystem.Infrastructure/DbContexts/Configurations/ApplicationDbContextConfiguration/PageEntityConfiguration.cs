using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Infrastructure.DbContexts.Configurations.ApplicationDbContextConfiguration;

public class PageEntityConfiguration : IEntityTypeConfiguration<Page>
{
    public void Configure(EntityTypeBuilder<Page> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Content);

        builder.Property(s => s.Number);

        builder.HasData(new[]
        {
            #region Some book 1

            new Page()
            {
                BookId = Guid.Parse("f0811a4e-628a-4e9b-98da-9e5523f1a6d3"),
                Id = Guid.Parse("8b177ac7-3d6e-47ca-ac5d-ef3cc6f3fa55"),
                Content = "some content 1",
                Number = 1
            },
            new Page()
            {
                BookId = Guid.Parse("f0811a4e-628a-4e9b-98da-9e5523f1a6d3"),
                Id = Guid.Parse("f7bc8168-ffdd-404a-bb3e-c78ff14c8ea7"),
                Content = "some content 2",
                Number = 2
            },
            new Page()
            {
                BookId = Guid.Parse("f0811a4e-628a-4e9b-98da-9e5523f1a6d3"),
                Id = Guid.Parse("36c60756-b7fd-4365-8d82-df6fbda877bf"),
                Content = "some content 3",
                Number = 3
            },

            #endregion

            #region Some book 2

            new Page()
            {
                BookId = Guid.Parse("73e03a55-d760-4415-aeb5-743e9dd79f20"),
                Id = Guid.Parse("5ad93bbb-6b4b-4808-b437-568243e89fc7"),
                Content = "some content 1",
                Number = 1
            },
            new Page()
            {
                BookId = Guid.Parse("73e03a55-d760-4415-aeb5-743e9dd79f20"),
                Id = Guid.Parse("9a399d4d-87bf-4e19-b957-074d6531655c"),
                Content = "some content 2",
                Number = 2
            },
            new Page()
            {
                BookId = Guid.Parse("73e03a55-d760-4415-aeb5-743e9dd79f20"),
                Id = Guid.Parse("bb1fdd84-f3b3-4b03-a3f5-db69d9609200"),
                Content = "some content 3",
                Number = 3
            },

            #endregion

            #region Some book 3

            new Page()
            {
                BookId = Guid.Parse("2ce20daa-4315-4a1d-b555-5a1d337de520"),
                Id = Guid.Parse("bb89b97b-64ef-44ab-bb96-bd320e0e1fc8"),
                Content = "some content 1",
                Number = 1
            },
            new Page()
            {
                BookId = Guid.Parse("2ce20daa-4315-4a1d-b555-5a1d337de520"),
                Id = Guid.Parse("e1658020-57c8-48c6-8bcf-f93be5aef382"),
                Content = "some content 2",
                Number = 2
            },
            new Page()
            {
                BookId = Guid.Parse("2ce20daa-4315-4a1d-b555-5a1d337de520"),
                Id = Guid.Parse("7149f0bd-a73e-4ba8-8f49-4161489569f9"),
                Content = "some content 3",
                Number = 3
            },

            #endregion

            #region Some book 4

            new Page()
            {
                BookId = Guid.Parse("49b1ba68-e260-4a7e-9e3f-da55f79c90f4"),
                Id = Guid.Parse("bfa3718f-419b-46c4-9658-c2206e498f4a"),
                Content = "some content 1",
                Number = 1
            },
            new Page()
            {
                BookId = Guid.Parse("49b1ba68-e260-4a7e-9e3f-da55f79c90f4"),
                Id = Guid.Parse("6357f595-d9b3-4602-b0ac-3cdd5c95a24e"),
                Content = "some content 2",
                Number = 2
            },
            new Page()
            {
                BookId = Guid.Parse("49b1ba68-e260-4a7e-9e3f-da55f79c90f4"),
                Id = Guid.Parse("ba60ae13-cc3d-4219-94db-333e17f5071b"),
                Content = "some content 3",
                Number = 3
            },

            #endregion

            #region Some book 5

            new Page()
            {
                BookId = Guid.Parse("dd582fe1-1b4b-4c10-910e-e41c8b78d30c"),
                Id = Guid.Parse("70a7ba0e-737f-41ea-9b52-4389108d6be9"),
                Content = "some content 1",
                Number = 1
            },
            new Page()
            {
                BookId = Guid.Parse("dd582fe1-1b4b-4c10-910e-e41c8b78d30c"),
                Id = Guid.Parse("2bd1969b-b48d-42d0-adad-f77bd7a600ac"),
                Content = "some content 2",
                Number = 2
            },
            new Page()
            {
                BookId = Guid.Parse("dd582fe1-1b4b-4c10-910e-e41c8b78d30c"),
                Id = Guid.Parse("2556a64c-1cc4-49c1-bc15-c4fb752a1f74"),
                Content = "some content 3",
                Number = 3
            },

            #endregion

            #region Other Some book 1

            new Page()
            {
                BookId = Guid.Parse("ac64849c-a923-4346-a2ad-6fa9d19cd2be"),
                Id = Guid.Parse("96541ea8-9cbe-4295-a9f4-89c4950dfcee"),
                Content = "some content 1",
                Number = 1
            },
            new Page()
            {
                BookId = Guid.Parse("ac64849c-a923-4346-a2ad-6fa9d19cd2be"),
                Id = Guid.Parse("08b6fed8-e200-41a4-a743-4451d4fd8853"),
                Content = "some content 2",
                Number = 2
            },
            new Page()
            {
                BookId = Guid.Parse("ac64849c-a923-4346-a2ad-6fa9d19cd2be"),
                Id = Guid.Parse("655f5d73-76eb-448d-96fe-34bb12872ed1"),
                Content = "some content 3",
                Number = 3
            },

            #endregion

            #region Other Some book 2

            new Page()
            {
                BookId = Guid.Parse("3efa03c9-c526-46ed-9808-835fd44a646e"),
                Id = Guid.Parse("03eeb89b-09e9-4886-9f41-536d8a34d142"),
                Content = "some content 1",
                Number = 1
            },
            new Page()
            {
                BookId = Guid.Parse("3efa03c9-c526-46ed-9808-835fd44a646e"),
                Id = Guid.Parse("9602c16a-41b0-4b40-bb3c-2ffd891ca7d6"),
                Content = "some content 2",
                Number = 2
            },
            new Page()
            {
                BookId = Guid.Parse("3efa03c9-c526-46ed-9808-835fd44a646e"),
                Id = Guid.Parse("28abde92-2599-4dc9-97e1-e90fd03ee878"),
                Content = "some content 3",
                Number = 3
            },

            #endregion

            #region Other Some book 3

            new Page()
            {
                BookId = Guid.Parse("73eddf44-edc3-441f-8366-27cdf6595bc7"),
                Id = Guid.Parse("b8a43bfc-6c1f-4749-91d3-723b41dfa21f"),
                Content = "some content 1",
                Number = 1
            },
            new Page()
            {
                BookId = Guid.Parse("73eddf44-edc3-441f-8366-27cdf6595bc7"),
                Id = Guid.Parse("6c9ecb04-e9c9-4a13-ac45-230a991e59d0"),
                Content = "some content 2",
                Number = 2
            },
            new Page()
            {
                BookId = Guid.Parse("73eddf44-edc3-441f-8366-27cdf6595bc7"),
                Id = Guid.Parse("7b506020-163a-4afc-b0fe-504c2b8ee9ef"),
                Content = "some content 3",
                Number = 3
            },

            #endregion

            #region Other Some book 4

            new Page()
            {
                BookId = Guid.Parse("4f47a31e-3a6b-4b61-8061-95c6619ae4f6"),
                Id = Guid.Parse("f6a4403d-1814-4807-8794-7f3ad0a8634d"),
                Content = "some content 1",
                Number = 1
            },
            new Page()
            {
                BookId = Guid.Parse("4f47a31e-3a6b-4b61-8061-95c6619ae4f6"),
                Id = Guid.Parse("7e15422f-1f81-4eee-ac55-7c6ad2bc4b15"),
                Content = "some content 2",
                Number = 2
            },
            new Page()
            {
                BookId = Guid.Parse("4f47a31e-3a6b-4b61-8061-95c6619ae4f6"),
                Id = Guid.Parse("b60db710-85c4-4451-a5b8-5cfbc7370ba8"),
                Content = "some content 3",
                Number = 3
            },

            #endregion
        });
    }
}