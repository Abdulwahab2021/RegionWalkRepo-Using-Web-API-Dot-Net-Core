using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalk.API.Migrations
{
    /// <inheritdoc />
    public partial class walkChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LengthInKm",
                table: "walks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LengthInKm",
                table: "walks");
        }
    }
}
