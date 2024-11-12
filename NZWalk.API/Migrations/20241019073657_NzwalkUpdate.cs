using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalk.API.Migrations
{
    /// <inheritdoc />
    public partial class NzwalkUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("647164aa-27d7-4c84-81fc-be52753c24d8"),
                column: "RegionImageUrl",
                value: "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1\"\n                },");

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "RegionImageUrl", "RegionName" },
                values: new object[] { new Guid("54571568-6cf0-4e40-a638-e4457f61bcfa"), "WGN", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Wellington" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("54571568-6cf0-4e40-a638-e4457f61bcfa"));

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("647164aa-27d7-4c84-81fc-be52753c24d8"),
                column: "RegionImageUrl",
                value: "pexleimage.jpg");
        }
    }
}
