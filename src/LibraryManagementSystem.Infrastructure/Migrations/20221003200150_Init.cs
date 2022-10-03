using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LibraryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb"), "Library one" });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea"), "Library three" });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("adea7009-34c0-4aa4-8284-d76757d2d5f2"), "Library two" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "LibraryId", "Title" },
                values: new object[,]
                {
                    { new Guid("2ce20daa-4315-4a1d-b555-5a1d337de520"), new Guid("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb"), "Some book 3" },
                    { new Guid("3efa03c9-c526-46ed-9808-835fd44a646e"), new Guid("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea"), "Other some book 2" },
                    { new Guid("49b1ba68-e260-4a7e-9e3f-da55f79c90f4"), new Guid("adea7009-34c0-4aa4-8284-d76757d2d5f2"), "Some book 4" },
                    { new Guid("4f47a31e-3a6b-4b61-8061-95c6619ae4f6"), new Guid("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea"), "Other some book 4" },
                    { new Guid("73e03a55-d760-4415-aeb5-743e9dd79f20"), new Guid("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb"), "Some book 2" },
                    { new Guid("73eddf44-edc3-441f-8366-27cdf6595bc7"), new Guid("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea"), "Other some book 3" },
                    { new Guid("ac64849c-a923-4346-a2ad-6fa9d19cd2be"), new Guid("adea7009-34c0-4aa4-8284-d76757d2d5f2"), "Other some book 1" },
                    { new Guid("dd582fe1-1b4b-4c10-910e-e41c8b78d30c"), new Guid("adea7009-34c0-4aa4-8284-d76757d2d5f2"), "Some book 5" },
                    { new Guid("f0811a4e-628a-4e9b-98da-9e5523f1a6d3"), new Guid("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb"), "Some book 1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_LibraryId",
                table: "Books",
                column: "LibraryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Libraries");
        }
    }
}
