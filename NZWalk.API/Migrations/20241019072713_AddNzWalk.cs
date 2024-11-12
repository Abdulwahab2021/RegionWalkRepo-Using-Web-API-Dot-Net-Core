using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalk.API.Migrations
{
    /// <inheritdoc />
    public partial class AddNzWalk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "walks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalkImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DifficultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_walks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_walks_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_walks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0e2f202e-0af6-4c91-9139-9153b950bbfa"), "Easy" },
                    { new Guid("0eedf313-3fbe-44b3-ab3a-74a4702436fd"), "Medium" },
                    { new Guid("17403890-c4f4-4cd4-81a9-f552524f2ae7"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "RegionImageUrl", "RegionName" },
                values: new object[,]
                {
                    { new Guid("4f4bcee7-d3bd-48bb-961b-7c7836bf8b96"), "STL", "", "SouthLand" },
                    { new Guid("647164aa-27d7-4c84-81fc-be52753c24d8"), "AKL", "pexleimage.jpg", "Auckland" },
                    { new Guid("94f069ad-79fe-4f89-bb95-322ab9d93dba"), "NSN", "", "Nelson" },
                    { new Guid("95cb4e28-78cb-4e71-b50f-df4fb635e55a"), "NTL", "", "NorthLan" },
                    { new Guid("d90f7a7b-dc1a-44e3-a5fe-ae22929aadf5"), "AKL", "", "Bay of Plenty" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_walks_DifficultyId",
                table: "walks",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_walks_RegionId",
                table: "walks",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "walks");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
