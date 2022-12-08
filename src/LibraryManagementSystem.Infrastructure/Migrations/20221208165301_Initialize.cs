using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Infrastructure.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[,]
                {
                    { new Guid("2ce20daa-4315-4a1d-b555-5a1d337de520"), "some random content 3", "Some book 3" },
                    { new Guid("3efa03c9-c526-46ed-9808-835fd44a646e"), "some random content 7", "Other some book 2" },
                    { new Guid("49b1ba68-e260-4a7e-9e3f-da55f79c90f4"), "some random content 4", "Some book 4" },
                    { new Guid("4f47a31e-3a6b-4b61-8061-95c6619ae4f6"), "some random content 9", "Other some book 4" },
                    { new Guid("73e03a55-d760-4415-aeb5-743e9dd79f20"), "some random content 2", "Some book 2" },
                    { new Guid("73eddf44-edc3-441f-8366-27cdf6595bc7"), "some random content 8", "Other some book 3" },
                    { new Guid("ac64849c-a923-4346-a2ad-6fa9d19cd2be"), "some random content 6", "Other some book 1" },
                    { new Guid("dd582fe1-1b4b-4c10-910e-e41c8b78d30c"), "some random content 5", "Some book 5" },
                    { new Guid("f0811a4e-628a-4e9b-98da-9e5523f1a6d3"), "some random content 1", "Some book 1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
