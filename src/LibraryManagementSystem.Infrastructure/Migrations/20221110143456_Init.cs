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
                name: "LibraryGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LibraryGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libraries_LibraryGroups_LibraryGroupId",
                        column: x => x.LibraryGroupId,
                        principalTable: "LibraryGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LibraryGroups",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7e281174-5f21-497b-a1ff-641ac1aff60e"), "Group 2" });

            migrationBuilder.InsertData(
                table: "LibraryGroups",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e7b2e4ff-9c8a-45c4-aec5-f949d419b9c0"), "Group 1" });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "LibraryGroupId", "Name" },
                values: new object[] { new Guid("7a6a4c0a-a8ae-452a-ab6d-2e43a2cc1ffb"), new Guid("e7b2e4ff-9c8a-45c4-aec5-f949d419b9c0"), "Library one" });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "LibraryGroupId", "Name" },
                values: new object[] { new Guid("9162218a-aefd-46a4-ba6d-2bb0b02ba8ea"), new Guid("7e281174-5f21-497b-a1ff-641ac1aff60e"), "Library three" });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "LibraryGroupId", "Name" },
                values: new object[] { new Guid("adea7009-34c0-4aa4-8284-d76757d2d5f2"), new Guid("e7b2e4ff-9c8a-45c4-aec5-f949d419b9c0"), "Library two" });

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

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "BookId", "Content", "Number" },
                values: new object[,]
                {
                    { new Guid("03eeb89b-09e9-4886-9f41-536d8a34d142"), new Guid("3efa03c9-c526-46ed-9808-835fd44a646e"), "some content 1", 1 },
                    { new Guid("08b6fed8-e200-41a4-a743-4451d4fd8853"), new Guid("ac64849c-a923-4346-a2ad-6fa9d19cd2be"), "some content 2", 2 },
                    { new Guid("2556a64c-1cc4-49c1-bc15-c4fb752a1f74"), new Guid("dd582fe1-1b4b-4c10-910e-e41c8b78d30c"), "some content 3", 3 },
                    { new Guid("28abde92-2599-4dc9-97e1-e90fd03ee878"), new Guid("3efa03c9-c526-46ed-9808-835fd44a646e"), "some content 3", 3 },
                    { new Guid("2bd1969b-b48d-42d0-adad-f77bd7a600ac"), new Guid("dd582fe1-1b4b-4c10-910e-e41c8b78d30c"), "some content 2", 2 },
                    { new Guid("36c60756-b7fd-4365-8d82-df6fbda877bf"), new Guid("f0811a4e-628a-4e9b-98da-9e5523f1a6d3"), "some content 3", 3 },
                    { new Guid("5ad93bbb-6b4b-4808-b437-568243e89fc7"), new Guid("73e03a55-d760-4415-aeb5-743e9dd79f20"), "some content 1", 1 },
                    { new Guid("6357f595-d9b3-4602-b0ac-3cdd5c95a24e"), new Guid("49b1ba68-e260-4a7e-9e3f-da55f79c90f4"), "some content 2", 2 },
                    { new Guid("655f5d73-76eb-448d-96fe-34bb12872ed1"), new Guid("ac64849c-a923-4346-a2ad-6fa9d19cd2be"), "some content 3", 3 },
                    { new Guid("6c9ecb04-e9c9-4a13-ac45-230a991e59d0"), new Guid("73eddf44-edc3-441f-8366-27cdf6595bc7"), "some content 2", 2 },
                    { new Guid("70a7ba0e-737f-41ea-9b52-4389108d6be9"), new Guid("dd582fe1-1b4b-4c10-910e-e41c8b78d30c"), "some content 1", 1 },
                    { new Guid("7149f0bd-a73e-4ba8-8f49-4161489569f9"), new Guid("2ce20daa-4315-4a1d-b555-5a1d337de520"), "some content 3", 3 },
                    { new Guid("7b506020-163a-4afc-b0fe-504c2b8ee9ef"), new Guid("73eddf44-edc3-441f-8366-27cdf6595bc7"), "some content 3", 3 },
                    { new Guid("7e15422f-1f81-4eee-ac55-7c6ad2bc4b15"), new Guid("4f47a31e-3a6b-4b61-8061-95c6619ae4f6"), "some content 2", 2 },
                    { new Guid("8b177ac7-3d6e-47ca-ac5d-ef3cc6f3fa55"), new Guid("f0811a4e-628a-4e9b-98da-9e5523f1a6d3"), "some content 1", 1 },
                    { new Guid("9602c16a-41b0-4b40-bb3c-2ffd891ca7d6"), new Guid("3efa03c9-c526-46ed-9808-835fd44a646e"), "some content 2", 2 },
                    { new Guid("96541ea8-9cbe-4295-a9f4-89c4950dfcee"), new Guid("ac64849c-a923-4346-a2ad-6fa9d19cd2be"), "some content 1", 1 },
                    { new Guid("9a399d4d-87bf-4e19-b957-074d6531655c"), new Guid("73e03a55-d760-4415-aeb5-743e9dd79f20"), "some content 2", 2 },
                    { new Guid("b60db710-85c4-4451-a5b8-5cfbc7370ba8"), new Guid("4f47a31e-3a6b-4b61-8061-95c6619ae4f6"), "some content 3", 3 },
                    { new Guid("b8a43bfc-6c1f-4749-91d3-723b41dfa21f"), new Guid("73eddf44-edc3-441f-8366-27cdf6595bc7"), "some content 1", 1 },
                    { new Guid("ba60ae13-cc3d-4219-94db-333e17f5071b"), new Guid("49b1ba68-e260-4a7e-9e3f-da55f79c90f4"), "some content 3", 3 },
                    { new Guid("bb1fdd84-f3b3-4b03-a3f5-db69d9609200"), new Guid("73e03a55-d760-4415-aeb5-743e9dd79f20"), "some content 3", 3 },
                    { new Guid("bb89b97b-64ef-44ab-bb96-bd320e0e1fc8"), new Guid("2ce20daa-4315-4a1d-b555-5a1d337de520"), "some content 1", 1 },
                    { new Guid("bfa3718f-419b-46c4-9658-c2206e498f4a"), new Guid("49b1ba68-e260-4a7e-9e3f-da55f79c90f4"), "some content 1", 1 },
                    { new Guid("e1658020-57c8-48c6-8bcf-f93be5aef382"), new Guid("2ce20daa-4315-4a1d-b555-5a1d337de520"), "some content 2", 2 },
                    { new Guid("f6a4403d-1814-4807-8794-7f3ad0a8634d"), new Guid("4f47a31e-3a6b-4b61-8061-95c6619ae4f6"), "some content 1", 1 },
                    { new Guid("f7bc8168-ffdd-404a-bb3e-c78ff14c8ea7"), new Guid("f0811a4e-628a-4e9b-98da-9e5523f1a6d3"), "some content 2", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_LibraryId",
                table: "Books",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_LibraryGroupId",
                table: "Libraries",
                column: "LibraryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_BookId",
                table: "Pages",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropTable(
                name: "LibraryGroups");
        }
    }
}
